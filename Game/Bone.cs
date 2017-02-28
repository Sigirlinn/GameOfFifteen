using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.Windows;

namespace Game
{
    public class Bone : INotifyPropertyChanged
    {

        private int[] numbers;
        private int[] answer = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

        public int[] Bones;
        public event PropertyChangedEventHandler PropertyChanged;
        public Bone()
        {
            Refresh();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Number0
        {
            get { return numbers[0]; }
            set
            {
                numbers[0] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number1
        {
            get { return numbers[1]; }
            set
            {
                numbers[1] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number2
        {
            get { return numbers[2]; }
            set
            {
                numbers[2] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number3
        {
            get { return numbers[3]; }
            set
            {
                numbers[3] = value;
                NotifyPropertyChanged();
            }
        }

        public int Number4
        {
            get { return numbers[4]; }
            set
            {
                numbers[4] = value;
                NotifyPropertyChanged();
            }

        }
        public int Number5
        {
            get { return numbers[5]; }
            set
            {
                numbers[5] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number6
        {
            get { return numbers[6]; }
            set
            {
                numbers[6] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number7
        {
            get { return numbers[7]; }
            set
            {
                numbers[7] = value;
                NotifyPropertyChanged();
            }
        }

        public int Number8
        {
            get { return numbers[8]; }
            set
            {
                numbers[8] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number9
        {
            get { return numbers[9]; }
            set
            {
                numbers[9] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number10
        {
            get { return numbers[10]; }
            set
            {
                numbers[10] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number11
        {
            get { return numbers[11]; }
            set
            {
                numbers[11] = value;
                NotifyPropertyChanged();
            }
        }

        public int Number12
        {
            get { return numbers[12]; }
            set
            {
                numbers[12] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number13
        {
            get { return numbers[13]; }
            set
            {
                numbers[13] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number14
        {
            get { return numbers[14]; }
            set
            {
                numbers[14] = value;
                NotifyPropertyChanged();
            }
        }
        public int Number15
        {
            get { return numbers[15]; }
            set
            {
                numbers[15] = value;
                NotifyPropertyChanged();
            }
        }

        public void Refresh()
        {
            numbers = boneGenerator(2);
            Number0 = numbers[0];
            Number1 = numbers[1];
            Number2 = numbers[2];
            Number3 = numbers[3];

            Number4 = numbers[4];
            Number5 = numbers[5];
            Number6 = numbers[6];
            Number7 = numbers[7];

            Number8 = numbers[8];
            Number9 = numbers[9];
            Number10 = numbers[10];
            Number11 = numbers[11];

            Number12 = numbers[12];
            Number13 = numbers[13];
            Number14 = numbers[14];
            Number15 = numbers[15];
        }

        public bool WinningCheck()
        {
            for (int i = 0; i < 16; i++)
                if (Bones[i] != answer[i]) return false;
            return true;
        }

        public int GetIndexFromMargin(Thickness bone, double step, double size)
        {
            double buf = step + size;
            int i = (int)(bone.Top / buf);
            int j = (int)(bone.Left / buf);
            return i * 4 + j;
        }

        private int[] generator()
        {
            int[] number = new int[16];
            Bones = new int[16];
            bool[] flag = new bool[16];
            Random r = new Random();
            for (int i = 0; i < 16; i++)
            {
                int buf = r.Next(0, 15);
                int k = 0;
                while (k < 16)
                {
                    if (flag[buf])
                    {
                        if (buf == 15) buf = 0;
                        else buf++;
                        k++;
                    }
                    else
                    {
                        number[i] = buf;
                        Bones[i] = buf;
                        flag[buf] = true;
                        break;
                    }
                }
            }
            return number;
        }

        private int[] boneGenerator(int step)
        {
            int[] number = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            Random r = new Random();
            int empty = 15;
            int i = 3, j = 3;
            while (step-- > 0)
            {
                Console.WriteLine(i.ToString() + " " + j.ToString());
                //выбираем как будем двигаться - по горизонтали или по вертикали
                int VorH = r.Next(0, 2);
                int directly = 1;
                if (VorH == 0)
                {
                    //по горизонтали
                    //выбираем в каком направлении - влево или вправо
                    if (j == 3) directly = -1;//влево
                    else if (j == 0) directly = 1;//вправо
                    else
                    {
                        int k = r.Next(0, 2);
                        if (k == 0) directly = -1;//влево
                        else directly = 1;//вправо
                    }
                    number[empty] = number[i * 4 + (j + directly)];
                    number[i * 4 + (j + directly)] = 0;

                    empty = i * 4 + (j + directly);
                    j += directly;
                }
                else
                {
                    //по вертикали
                    //вверх или вниз
                    if (i == 3) directly = -1;//вверх
                    else if (i == 0) directly = 1;//вниз
                    else
                    {
                        int k = r.Next(0, 2);
                        if (k == 0) directly = -1;//вверх
                        else directly = 1;//вниз
                    }
                    number[empty] = number[(i + directly) * 4 + j];
                    number[(i + directly) * 4 + j] = 0;

                    empty = (i + directly) * 4 + j;
                    i += directly;
                }
                
            }
            Console.WriteLine(i.ToString() + " " + j.ToString());
            Bones = new int[16];
            for (int g = 0; g < 16; g++) Bones[g] = number[g]; 
            return number;
        }
    }
}
