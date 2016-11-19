using EntityHelper;
using Integracje.UI.SrvBook;
using Newtonsoft.Json;
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
using Procedure = Integracje.UI.SrvBook.Procedure;

namespace Integracje.UI.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ICommand m_DownloadCommand;
        public ICommand DownloadCommand
        {
            get
            {
                if (m_DownloadCommand == null)
                {
                    m_DownloadCommand = new DelegateCommand(ExecuteSelectedProcedure, CanExecuteDownloadCommand);
                }
                return m_DownloadCommand;
            }
        }

        private void ExecuteSelectedProcedure()
        {
            try
            {
                SelectedProcedure.Parameter = ParameterTextBox;

                var ws = new BookService();
                var resultJson = ws.GetResultFromProcedure(SelectedProcedure);

                Result = JsonConvert.DeserializeObject<ResultFromProcedure>(resultJson);

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
        }

        private bool CanExecuteDownloadCommand()
        {
            return SelectedProcedure != null ? true : false;
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
            set
            {
                SetProperty(ref m_SelectedProcedure, value);
                ((DelegateCommand)DownloadCommand).RaiseCanExecuteChanged();
            }
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
