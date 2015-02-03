﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading ;
using System.Windows.Forms;
using HartSDK;

namespace HartTool
{
    public partial class Frm多点线性化 : Form, IHartCommunication
    {
        public Frm多点线性化()
        {
            InitializeComponent();
        }

        #region 私有变量
        private bool _Running = false;
        private Thread _TrdReadAD = null;
        #endregion

        #region 私有方法
        private void ReadAD_Task()
        {
            try
            {
                while (_Running)
                {
                    Thread.Sleep(AppSettings.Current.RealInterval);
                    if (HartDevice != null && HartDevice.IsConnected)
                    {
                        float ad = HartDevice.ReadPVAD(false);
                        this.Invoke((Action)(() =>
                        {
                            if (ad > 0)
                            {
                                txtAD.Text = ad.ToString("F0");
                            }
                        }));
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                _TrdReadAD = null;
            }
        }
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            btnRead.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnWrite.Enabled = HartDevice != null && HartDevice.IsConnected;
        }

        private void ReadLinearizationItems()
        {
            FrmProcessing frm = new FrmProcessing();
            Action a = delegate()
            {
                try
                {
                    int maxAD = 70000;
                    if (HartDevice != null && HartDevice.IsConnected)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            LinearizationItem li = null;
                            for (int j = 0; j < 4; j++) //由于有时会读不到数据,所以每组数据在读取失败时会重新偿试读三次
                            {
                                li = HartDevice.ReadLinearizationItem((byte)i);
                                if (li != null) break;
                                Thread.Sleep(500);
                            }
                            if (li != null && li.SensorAD == maxAD) break; //后面的都是无效的参数了,不用再继续获取
                            this.Invoke((Action)(() =>
                            {
                                (this.Controls["txtP" + i.ToString()] as TextBox).Text = li != null ? li.SensorValue.ToString() : null;
                                (this.Controls["txtAD" + i.ToString()] as TextBox).Text = li != null ? li.SensorAD.ToString() : null;
                            }));
                            frm.ShowProgress(string.Empty, (decimal)i / 10);
                        }
                    }
                    frm.ShowProgress(string.Empty, 1);
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception)
                {
                }

            };
            Thread t = new Thread(new ThreadStart(a));
            t.IsBackground = true;
            t.Start();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                t.Abort();
            }
        }

        private void WriteLinearizationItems(List<LinearizationItem> lis)
        {
            FrmProcessing frm = new FrmProcessing();
            Action action = delegate()
            {
                try
                {
                    for (int i = 0; i < lis.Count; i += 2)
                    {
                        LinearizationItem[] items = new LinearizationItem[2] { lis[i], lis[i + 1] };
                        bool ret = HartDevice.WriteLinearizationItems(items, (byte)(i / 2));
                        frm.ShowProgress(string.Empty, (decimal)(i + 2) / lis.Count);
                        Thread.Sleep(100);
                    }
                    frm.ShowProgress(string.Empty, 1);
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception)
                {
                }
            };
            Thread t = new Thread(new ThreadStart(action));
            t.IsBackground = true;
            t.Start();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                t.Abort();
            }
        }
        #endregion

        #region 事件处理程序
        private void Frm多点线性化_Load(object sender, EventArgs e)
        {
            _TrdReadAD = new Thread(new ThreadStart(ReadAD_Task));
            _TrdReadAD.IsBackground = true;
            _Running = true;
            _TrdReadAD.Start();
        }

        private void Frm多点线性化_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_TrdReadAD != null) _Running = false;
        }

        private void txtP1_Enter(object sender, EventArgs e)
        {
            string temp = (sender as Control).Tag.ToString();
            if (this.Controls["button" + temp] != null)
            {
                for (int i = 1; i <= 10; i++)
                {
                    this.Controls["button" + i.ToString()].Enabled = i.ToString() == temp;
                }
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (HartDevice == null || !HartDevice.IsConnected) return;
            string temp = (sender as Control).Tag.ToString();
            int ind = 0;
            if (int.TryParse(temp, out ind) && ind >= 1 && ind <= 10)
            {
                (this.Controls["txtAD" + ind.ToString()] as TextBox).Text = HartDevice.ReadPVAD(false).ToString("F0");
                if (ind < 10)
                {
                    (this.Controls["txtP" + (ind + 1).ToString()] as TextBox).Focus();
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadLinearizationItems();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (HartDevice == null || !HartDevice.IsConnected) return;
            List<LinearizationItem> lis = new List<LinearizationItem>();
            for (int i = 1; i <= 10; i++)
            {
                string strP = (this.Controls["txtP" + i.ToString()] as TextBox).Text;
                string strAD = (this.Controls["txtAD" + i.ToString()] as TextBox).Text;
                float fp = 0;
                float fAD = 0;
                if (!string.IsNullOrEmpty(strP) && !string.IsNullOrEmpty(strAD))
                {
                    if (float.TryParse(strP, out fp) && fp >= 0 && float.TryParse(strAD, out fAD) && fAD >= 0)
                    {
                        if (!(fp == 0 && fAD == 0)) //同时为零的点忽略掉
                        {
                            LinearizationItem li = new LinearizationItem() { SensorValue = fp, SensorAD = fAD };
                            lis.Add(li);
                        }
                    }
                }
            }
            if (lis.Count <= 1)
            {
                MessageBox.Show("至少要设置2个线性化点");
                return;
            }
            LinearizationItem.FillHeaderAndTail(lis);
            WriteLinearizationItems(lis);
        }
        #endregion
    }
}
