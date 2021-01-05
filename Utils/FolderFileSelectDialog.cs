using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Utils
{
	class FolderFileSelectDialog
	{
		private OpenFileDialog openFileDialog = null;

		public static OpenFileDialog GetFileDialog() {

			return new OpenFileDialog
            {

                CheckFileExists = false,
                DereferenceLinks = true,
                Multiselect = false,
				Title = "What to select",
				InitialDirectory = @"c:\"
			};
		}

		public static FolderBrowserDialog GetFolderDialog()
		{

			return new FolderBrowserDialog
			{
				Description = "Destinaton Folder",
				Tag = "test"
			};
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
