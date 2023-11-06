using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_DZ_5.Models
{
    internal class Generator
    {
        private int Length;

        public Generator(int length, bool[] options)
        {
            Length = length;
            Options = options;
        }

        public int Lendht
        {
            get { return Length; }
            set { Length = value>0?value:1; }
        }
        public bool[] Options {  get; set; }
        public string Generate()
        {
            string password = Options[4] ? GeneratorWithNoRepetitions() : GeneratorWithRepetitions();
            return password;
        }

        private string GeneratorWithRepetitions()
        {
            var st = new StringBuilder(Length);
            Random r = new();
            for (int i = 0; i < Length; i++)
            {
                switch (r.Next(1, 5))
                {
                    case 1:
                        {
                            if (Options[0])
                            {
                                st.Append(GetNumber(r));
                            }
                            else
                            {
                                i--;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Options[1])
                            {
                                st.Append(GetLowerLetter(r));
                            }
                            else
                            {
                                i--;
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Options[2])
                            {
                                st.Append(GetUpperLetter(r));
                            }
                            else
                            {
                                i--;
                            }
                        }
                        break;
                    case 4:
                        {
                            if (Options[3])
                            {
                                st.Append(GetSpecialSymbol(r));
                            }
                            else
                            {
                                i--;
                            }
                        }
                        break;
                }         
            }
            return st.ToString();
        }

        private string GeneratorWithNoRepetitions()
        {
          var st=new StringBuilder(Length);
            Random r = new();
            for(int i=0; i<Length; i++) 
            {
                switch (r.Next(1, 5))
                {
                    case 1:
                        {
                            if (Options[0])
                            {
                                st.Append(GetNumber(r));
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Options[1])
                            {
                                st.Append(GetLowerLetter(r));
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Options[2])
                            {
                                st.Append(GetUpperLetter(r));
                            }
                        }
                        break;
                    case 4:
                        {
                            if (Options[3])
                            {
                                st.Append(GetSpecialSymbol(r));
                            }
                        }
                        break;
                }
                if(st.Length>1)
                {
                    char c = st[st.Length - 1];
                    for(int j=0; j<Length-1; j++)
                    {
                        if (st[j].Equals(c))
                        {
                            i--;
                            break;
                        }
                    }
                }
            }
            return st.ToString();
        }
        string GetNumber(Random r) => char.ConvertFromUtf32(r.Next(48,58));
        string GetUpperLetter(Random r)=> char.ConvertFromUtf32(r.Next(65, 91));
        string GetLowerLetter(Random r) => char.ConvertFromUtf32(r.Next(97, 123));
        string GetSpecialSymbol(Random r) => char.ConvertFromUtf32(r.Next(97, 123));
    }
}
