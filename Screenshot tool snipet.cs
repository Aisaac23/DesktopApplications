private void Take_Screenshot(int timeMS)
{
	//this.radioButton1.Checked = false;
	System.Threading.Thread.Sleep(timeMS);

	Bitmap memoryImage;

	
	if (prim)
	{
		memoryImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.WorkingArea.Height);
		Size s = new Size(memoryImage.Width, memoryImage.Height);
		Graphics memoryGraphics = Graphics.FromImage(memoryImage);
		memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
	}
	else
	{

		memoryImage = new Bitmap(Screen.AllScreens[1].Bounds.Width, Screen.AllScreens[1].WorkingArea.Height);
		Size s = new Size(memoryImage.Width, memoryImage.Height);
		Graphics memoryGraphics = Graphics.FromImage(memoryImage);
		memoryGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.Width, 0, 0, 0, s);
	}

	string str = "";

	String filePath = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
	 @"\Screenshots\" + DateTime.Now.ToString("dd-MM-yy") + "\\");
	System.IO.FileInfo file = new System.IO.FileInfo(filePath);
	file.Directory.Create();
	str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
	 @"\Screenshots\" + DateTime.Now.ToString("dd-MM-yy") + "\\" + DateTime.Now.ToString("dd-MM-yy") + " " + DateTime.Now.ToString("[hh-mm-ss]") + ".png");

	memoryImage.Save(str);
	this.radioButton1.Checked = true;
}