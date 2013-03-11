﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public partial class MergeVisioFiles : Form
    {
        public MergeVisioFiles()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Visio Documents|*.vsd";
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() != DialogResult.Cancel)
            {
                foreach (var item in fileDialog.FileNames)
                {
                    var equalItems = from cc in lbFilesToMerge.Items.Cast<string>()
                                     where cc == item
                                     select cc;

                    if (equalItems.Count() == 0)
                    {
                        lbFilesToMerge.Items.Add(item);
                    }
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //for (int i = lbFilesToMerge.SelectedIndices.Count; i > 0; i--)
            //{
            //    lbFilesToMerge.Items.RemoveAt(lbFilesToMerge.SelectedIndices[i]);
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ModelMerger merger = new ModelMerger();
            merger.FilesToMerge = lbFilesToMerge.Items.Cast<string>().ToList();
            DialogResult result = MessageBox.Show("All open docs will be closed without saving. Do you want to continue?",
                "Promoveo For Visio", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                merger.StartMerge();
            }
        }


    }
}
