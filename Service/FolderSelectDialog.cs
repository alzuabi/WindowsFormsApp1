using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Service
{
	class FolderSelectDialog
	{
		public OpenFileDialog openFileDialog = null;

		public FolderSelectDialog()
		{
			openFileDialog = new OpenFileDialog();

			//ofd.Filter = "Folders|\n";
			//ofd.AddExtension = false;
			openFileDialog.CheckFileExists = false;
			openFileDialog.DereferenceLinks = true;
			openFileDialog.Multiselect = false;
		}


		#region Properties

		/// <summary>
		/// Gets/Sets the initial folder to be selected. A null value selects the current directory.
		/// </summary>
		public string InitialDirectory
		{
			get { return openFileDialog.InitialDirectory; }
			set { openFileDialog.InitialDirectory = value == null || value.Length == 0 ? Environment.CurrentDirectory : value; }
		}

		/// <summary>
		/// Gets/Sets the title to show in the dialog
		/// </summary>
		public string Title
		{
			get { return openFileDialog.Title; }
			set { openFileDialog.Title = value == null ? "Select a folder" : value; }
		}

		/// <summary>
		/// Gets the selected folder
		/// </summary>
		public string FileName
		{
			get { return openFileDialog.FileName; }
		}

		public DialogResult ShowDialog
		{
			get
			{
				return openFileDialog.ShowDialog();
			}
			#endregion
		}
	}

}
