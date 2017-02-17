using PolyTool3.Graphic.Backgrounds;
using PolyTool3.Graphic.Lights;
using PolyTool3.Graphic.Renderers;
using PolyTool3.Graphic.Structures;
using PolyTool3.Graphic.Surfaces;
using PolyTool3.Polygons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyTool3.UserControls
{
	public partial class Window : Form
	{
		private List<Polygon> polygons;
		private Renderer renderer;
		private Canvas canvas;
		private Timer timer;

		public Window()
		{
			InitializeComponent();
			InitializeCanvas();
			InitializeTimer();
			InitializeLight();
		}

		public void InitializeCanvas()
		{
			polygons = new List<Polygon>();
			renderer = new Renderer(polygons);
			canvas = new Canvas(renderer, polygons);

			canvas.Location = Point.Empty;
			canvas.Width = splitContainer1.Panel1.Width;
			canvas.Height = splitContainer1.Panel1.Height;
			canvas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			splitContainer1.Panel1.Controls.Add(canvas);

			functionListBox.SelectedIndex = 0;
		}

		public void InitializeTimer()
		{
			timer = new Timer();
			timer.Tick += new EventHandler((sender, e) =>
			{
				if(renderer.Light != null)
				{
					renderer.Light.Angle += 1;
				}
				canvas.Invalidate();
			});
			timer.Interval = 1;
		}

		public void InitializeLight()
		{
			CentralizeLight();

			xLightTextBox.Enabled = false;
			yLightTextBox.Enabled = false;
			heightLightTextBox.Enabled = false;
			radiusLightTextBox.Enabled = false;
			centerLightButton.Enabled = false;
		}

		private void NoBackground_ChangeRequest(object sender, EventArgs e)
		{
			if (noBackgroundRadioButton.Checked)
			{
				renderer.Background = null;
				backgroundColorButton.BackColor = Color.Transparent;
				canvas.Invalidate();
			}
		}

		private void BackgroundColor_ChangeRequest(object sender, EventArgs e)
		{
			if(backgroundcolorRadioButton.Checked)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					renderer.Background = new ColorBackground(dialog.Color);
					backgroundColorButton.BackColor = dialog.Color;
					canvas.Invalidate();
				}
				else
				{
					backgroundcolorRadioButton.Checked = false;
					noBackgroundRadioButton.Checked = true;
				}
			}
		}

		private void BackgroundImage_ChangeRequest(object sender, EventArgs e)
		{
			if (backgroundBitmapRadioButton.Checked)
			{
				FileDialog dialog = new OpenFileDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					Bitmap bitmap = new Bitmap(dialog.FileName);
					renderer.Background = DirectBitmap.FromBitmap(bitmap);
					canvas.Invalidate();
				}
				else
				{
					backgroundBitmapRadioButton.Checked = false;
					noBackgroundRadioButton.Checked = true;
				}
			}
		}

		private void NoLight_ChangeRequest(object sender, EventArgs e)
		{
			if (noLightRadioButton.Checked)
			{
				renderer.Light = null;
				lightColorButton.BackColor = Color.Transparent;
				canvas.Invalidate();

				xLightTextBox.Enabled = false;
				yLightTextBox.Enabled = false;
				heightLightTextBox.Enabled = false;
				radiusLightTextBox.Enabled = false;
				centerLightButton.Enabled = false;
			}
		}

		private void ConstantLight_ChangeRequest(object sender, EventArgs e)
		{
			if (constantLightRadioButton.Checked)
			{
				Color Color = renderer.Light != null ? renderer.Light.Color : Color.White;
				renderer.Light = new ConstantLight(Color);
				lightColorButton.BackColor = Color;
				canvas.Invalidate();

				xLightTextBox.Enabled = false;
				yLightTextBox.Enabled = false;
				heightLightTextBox.Enabled = false;
				radiusLightTextBox.Enabled = false;
				centerLightButton.Enabled = false;
			}
		}

		private void AnimatedLight_ChangeRequest(object sender, EventArgs e)
		{
			if (animatedLightRadioButton.Enabled)
			{
				int X, Y, Height, Radius;
				int.TryParse(xLightTextBox.Text, out X);
				int.TryParse(yLightTextBox.Text, out Y);
				int.TryParse(heightLightTextBox.Text, out Height);
				int.TryParse(radiusLightTextBox.Text, out Radius);
				Color Color = renderer.Light != null ? renderer.Light.Color : Color.White;

				renderer.Light = new AnimatedPointLight(X, Y, Height, Radius, Color);
				lightColorButton.BackColor = Color;
				timer.Start();

				xLightTextBox.Enabled = true;
				yLightTextBox.Enabled = true;
				heightLightTextBox.Enabled = true;
				radiusLightTextBox.Enabled = true;
				centerLightButton.Enabled = true;
			}
			else
			{
				timer.Stop();

				xLightTextBox.Enabled = false;
				yLightTextBox.Enabled = false;
				heightLightTextBox.Enabled = false;
				radiusLightTextBox.Enabled = false;
				centerLightButton.Enabled = false;
			}
		}

		private void AnimatedLight_PropertiesChanged(object sender, EventArgs e)
		{
			int value;
			if (renderer.Light != null)
			{
				if (int.TryParse(xLightTextBox.Text, out value))
				{
					renderer.Light.X = value;
				}
				if (int.TryParse(yLightTextBox.Text, out value))
				{
					renderer.Light.Y = value;
				}
				if (int.TryParse(radiusLightTextBox.Text, out value))
				{
					renderer.Light.Radius = value;
				}
				if (int.TryParse(heightLightTextBox.Text, out value))
				{
					renderer.Light.Height = value;
				}
			}
		}

		private void lightColorButton_Click(object sender, EventArgs e)
		{
			if (!noLightRadioButton.Checked)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					renderer.Light.Color = dialog.Color;
					lightColorButton.BackColor = dialog.Color;
					canvas.Invalidate();
				}
			}
		}

		private void centerLightButton_Click(object sender, EventArgs e)
		{
			CentralizeLight();
			AnimatedLight_ChangeRequest(sender, e);
		}

		private void CentralizeLight()
		{
			int X = ClientRectangle.Width / 2;
			int Y = ClientRectangle.Height / 2;
			int Height = 100;
			int Radius = 100;

			xLightTextBox.Text = X.ToString();
			yLightTextBox.Text = Y.ToString();
			heightLightTextBox.Text = Height.ToString();
			radiusLightTextBox.Text = Radius.ToString();
		}

		private void Surface_ChangeRequest(object sender, EventArgs e)
		{
			int x = ClientRectangle.Width / 2;
			int y = ClientRectangle.Height / 2;

			switch (functionListBox.SelectedIndex)
			{
				case 0:
					renderer.Function = new Plane(0);
					break;
				case 1:
					renderer.Function = new Cone(-2.5, x, y);
					break;
				case 2:
					renderer.Function = new Paraboloid(-0.005, x, y);
					break;
				case 3:
					renderer.Function = new HyperbolicParaboloid(-0.0005, x, y);
					break;
			}
			canvas?.Invalidate();
		}

		private void bumpMappingEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if(bumpMappingEnabled.Checked)
			{
				FileDialog dialog = new OpenFileDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					Bitmap bitmap = new Bitmap(dialog.FileName);
					renderer.BumpMap = DirectBitmap.FromBitmap(bitmap);
					canvas.Invalidate();
				}
			}
			else
			{
				renderer.BumpMap = null;
				canvas.Invalidate();
			}
		}

		private void BumpMap_ChangeRequest(object sender, EventArgs e)
		{
			FileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Bitmap bitmap = new Bitmap(dialog.FileName);
				renderer.BumpMap = DirectBitmap.FromBitmap(bitmap);
				bumpMappingEnabled.Checked = true;
				canvas.Invalidate();
			}
		}
	}
}
