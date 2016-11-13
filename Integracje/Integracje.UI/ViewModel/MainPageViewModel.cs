using EntityHelper;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Integracje.UI.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand DownloadCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        var ws = new WebService1.WebService1();
                        ws.CookieContainer = new System.Net.CookieContainer();

                        OutputTextBox = ws.HelloWorld();

                        return;
                        SelectedProcedure.Parameter = ParameterTextBox;
                        Result = SelectedProcedure.GetResult();

                        if (Result.HasError)
                        {
                            if (Result.WrongParameter)
                            {
                                OutputTextBox = "Zły parametr";
                            }
                            else
                            {
                                OutputTextBox = Result.ErrorMessage;
                            }
                            DeleteFile();
                        }
                        else
                        {
                            if (Result.EmptyResult)
                            {
                                OutputTextBox = "Brak rekordów";
                                DeleteFile();
                            }
                            else
                            {
                                OutputTextBox = Result.Xml;
                                CreateXmlFile();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        OutputTextBox = e.Message;
                    }
                });
            }
        }

        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private string name = "Result.xml";
        private string file;

        private void DeleteFile()
        {
            try
            {
                File.Delete(file);
            }
            catch { }
        }

        private void CreateXmlFile()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(file));
            }
            catch { }
            try
            {
                File.WriteAllText(file, Result.Xml);
            }
            catch { }
        }

        public ResultFromProcedure Result { get; set; }

        private string m_ParameterTextBox;

        public string ParameterTextBox
        {
            get { return m_ParameterTextBox; }
            set { SetProperty(ref m_ParameterTextBox, value); }
        }

        private Procedure m_SelectedProcedure;

        public Procedure SelectedProcedure
        {
            get { return m_SelectedProcedure; }
            set { SetProperty(ref m_SelectedProcedure, value); }
        }

        private ObservableCollection<Procedure> m_Procedures;
        public ObservableCollection<Procedure> Procedures
        {
            get { return m_Procedures; }
            set { SetProperty(ref m_Procedures, value); }
        }

        private string m_OutputTextBox;
        public string OutputTextBox
        {
            get { return m_OutputTextBox; }
            set { SetProperty(ref m_OutputTextBox, value); }
        }
        public MainPageViewModel()
        {
            file = path + "\\Results\\" + name;
            Procedures = new ObservableCollection<Procedure>
            {
                new Procedure {Name= "GetAllBooks",HasParameter=false},
                new Procedure {Name= "GetBookById",HasParameter=true,ParameterName="@id"},
                new Procedure {Name= "GetMostTranslatedBooks",HasParameter=false},
                new Procedure {Name= "GetOldestBookOrBooks",HasParameter=false},
                new Procedure {Name= "GetYoungestBookOrBooks",HasParameter=false},
                new Procedure {Name= "GetAllFactBasedBooks",HasParameter=false},
                new Procedure {Name= "GetAllNonFactBasedBooks",HasParameter=false},
                new Procedure {Name= "GetAllBooksInYear",HasParameter=true,ParameterName="@year"},
                new Procedure {Name= "GetAllBooksWrittenByMen",HasParameter=false},
                new Procedure {Name= "GetAllBooksWrittenByWomen",HasParameter=false}
            };
            OutputTextBox = string.Empty;
        }
    }
}
