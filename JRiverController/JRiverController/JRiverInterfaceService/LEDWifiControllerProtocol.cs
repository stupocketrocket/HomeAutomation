using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRiverInterfaceService
{
	class LEDWifiControllerProtocol
	{

		public sbyte[] IC_number;
		private sbyte RGB_sort;
		private sbyte Reserve;
		private sbyte[] all;
		private sbyte bar_no;
		private sbyte checkValue;
		private sbyte[] colorRGB;
		private sbyte controller;
		private sbyte dynamic_effect;
		private sbyte dynamic_mode;
		private sbyte[] frameHead = {-99, 98};
		private sbyte pause;
		private sbyte product;
		private sbyte product_mode;
		private sbyte speed;
		private sbyte static_dynamic;
		private sbyte switch_on;

	    public LEDWifiControllerProtocol()
		{
			all = new sbyte[20];
			colorRGB = new sbyte[3];
			IC_number = new sbyte[2];
			Reserve = 0;
		}

		public void TestInitialise()
		{
            Product = 0;
            ProductMode = 0;
            StaticDynamic = 1;
            SwitchOn = 1;
            BarNo = 50;
            SetColorRGB(255, 6, 32);
            Speed = 0;
            Pause = 0;
            DynamicMode = 0;
            DynamicEffect = 0;
            Controller = 0;
            RGBSort = 0;
		    setIC_number(0);
		    SetCurrentCheckSumValue();
            SetAll();
		}


		public static int byte2int(sbyte[] abyte0)
		{
			return abyte0[1] & 0xff | abyte0[0] << 8 & 0xff00;
		}

		private void exchangeInt(int[] ai)
		{
			int i = ai[0];
			int j = ai[1];
			ai[0] = (i & 0xf0) + ((j & 0xf0) >> 4);
			ai[1] = ((i & 0xf) << 4) + (j & 0xf);
		}

		public static sbyte getCheckValue(int i, int j, int k, int l, int i1, int j1)
		{
			i = j1 + i1 + l + k + j + i + 255;
			if (i != 0);
				j = i % 255;
			i = j;
			if (j == 0)
			{
				i = 255;
			}
			return (sbyte)i;
		}

		public static sbyte[] shortToByteArray(short word0)
		{
	        sbyte[] abyte0 = new sbyte[2];
		    int i = 0;
			do
			{
				if (i >= 2)
				{
	                return abyte0;
		        }
			    abyte0[i] = (sbyte)(word0 >> (abyte0.Count() - 1 - i) * 8 & 0xff);
				i++;
			} while (true);
		}

		public void exchangeBytes()
		{
			int []ai = new int[2];
			int i = 2;
			do
			{
				if (i >= 11)
				{
					return;
				}
				ai[0] = all[i];
				ai[1] = all[21 - i];
				exchangeInt(ai);
				all[i] = (sbyte)ai[0];
				all[21 - i] = (sbyte)ai[1];
				i++;
			} while (true);
	    }

		public sbyte[] GetAll()
		{
			return all;
		}

		public void SetAll()
		{
			all[0] = frameHead[0];
			all[1] = frameHead[1];
			all[2] = product;
			all[3] = product_mode;
			all[4] = static_dynamic;
			all[5] = switch_on;
			all[6] = bar_no;
			all[7] = colorRGB[0];
			all[8] = colorRGB[1];
			all[9] = colorRGB[2];
			all[10] = speed;
			all[11] = pause;
			all[12] = dynamic_mode;
			all[13] = dynamic_effect;
			all[14] = controller;
			all[15] = RGB_sort;
			all[16] = IC_number[0];
			all[17] = IC_number[1];
			all[18] = Reserve;
			all[19] = checkValue;
		}

		public sbyte BarNo
		{
			set { bar_no = value; }
            get { return bar_no; }
		}

		public void SetColorRGB(byte R, byte G, byte B)
		{
			Red = R;
			Green = G;
			Blue = B;
		}

		public byte Red
		{
			set { colorRGB[0] = (sbyte)value; }
            get { return (byte)colorRGB[0]; }
		}

		public byte Green
		{
			set { colorRGB[1] = (sbyte)value; }
            get { return (byte)colorRGB[1]; }
		}

		public byte Blue
		{
			set { colorRGB[2] = (sbyte)value; }
            get { return (byte)colorRGB[2]; }
		}

		public sbyte Controller
		{
			set { controller = value; }
		}

		private void setCurCheckValue(int i, int j, int k, int l, int i1, int j1)
		{
			i = j1 + i1 + l + k + j + i + 255;
			if (i == 0)
			{
				return;
			}
			j = i % 255;
			i = j;
			if (j == 0)
			{
				i = 255;
			}
			checkValue = (sbyte)i;
		}

		public void SetCurrentCheckSumValue()
		{
			setCurCheckValue(BarNo, Red, Green, Blue, SwitchOn, ProductMode);
		}

		public sbyte DynamicEffect
		{
			set { dynamic_effect = value; }
		}

		public sbyte DynamicMode
		{
			set { dynamic_mode = value; }
		}

		public void setIC_number(int i)
		{
			IC_number = shortToByteArray((short)i);
		}

		public sbyte Pause
		{
			set { pause = value; }
		}

		public sbyte Product
		{
			set { product = value; }
		}

		public sbyte ProductMode
		{
			set { product_mode = value; }
            get { return product_mode; }
		}

		public sbyte RGBSort
		{
			set { RGB_sort = value; }
		}

		public sbyte Speed
		{
			set { speed = value; }
		}

		public sbyte StaticDynamic
		{
			set { static_dynamic = value; }
		}

		public sbyte SwitchOn
		{
			set {switch_on = value;}
            get { return switch_on; }
		}

        public byte[] GetPacket()
        {
            SetCurrentCheckSumValue();
            SetAll();
            //exchangeBytes();
            sbyte[] allLocal = GetAll();
            //byte[] unsignedAll = (byte[])(Array)allLocal;

            byte[] unsignedAll = Array.ConvertAll(allLocal, (a) => (byte)a);
            return unsignedAll;
        }

	}
}
