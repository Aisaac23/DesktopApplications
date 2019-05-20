private void Take_Screenshot(int timeMS)
{
	//Waits a specific time in miliseconds, depending on your implementation you could multiply 
	//the value passed to the function by 1000.
	System.Threading.Thread.Sleep(timeMS);

	Bitmap memoryImage;
	int screenWidth = 0;

	/************These flags are to be set normally with checkboxes from the GUI*****************/
	bool primary = true;
	bool clipboard = true;
	bool taskBar = false;
	/************************************************************************/
	
	if (primary) 
		memoryImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, //if taskbar flag is set we include the taskbar in the screenshot
	(taskBar ? Screen.PrimaryScreen.Bounds.Height : Screen.PrimaryScreen.WorkingArea.Height) );
	else
	{	
		//We take both screens instead just the primary one.
		memoryImage = new Bitmap(Screen.AllScreens[1].Bounds.Width, Screen.AllScreens[1].WorkingArea.Height);
		//If it's the secondary screen the one we want, we asign to the variable "screenWidth" the width of
		//the primary screen, this way when we use "CopyFromScreen" we'll start from the end of the primary screen
		screenWidth = Screen.PrimaryScreen.Bounds.Width;
	}
	
	Size s = new Size(memoryImage.Width, memoryImage.Height);
	Graphics memoryGraphics = Graphics.FromImage(memoryImage);
	//Coordinates sourceX, SourceY, DestinationX, DestinationY, Size
	memoryGraphics.CopyFromScreen(screenWidth, 0, 0, 0, s);
	
	if(clipboard)//if clipboard flag is set we copy it to clipboard
		System.Windows.Forms.Clipboard.SetImage(memoryImage);
	
	string str = "";
	//We create the folder if it doesn't exist *****************************************
	String filePath = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
	 @"\Confidential\Screenshots\" + DateTime.Now.ToString("dd-MM-yy") + "\\");
	 
	System.IO.FileInfo file = new System.IO.FileInfo(filePath);
	file.Directory.Create();
	/********************************************************/
	//We asign a name to the screenshot we're going to save.
	str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
	 @"\Confidential\Screenshots\" + DateTime.Now.ToString("dd-MM-yy") + "\\" + DateTime.Now.ToString("dd-MM-yy") + " " + DateTime.Now.ToString("[hh-mm-ss]") + ".png");
	
	//We finally save the screnshot
	memoryImage.Save(str);
}
