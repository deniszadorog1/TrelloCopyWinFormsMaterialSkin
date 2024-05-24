using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

using TrelloCopyWinForms.Windows.EnterAccount;
using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Windows.UserMainMenu;
using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows;
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;

namespace TrelloCopyWinForms
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            InitFacePic();

            DBUsage.InitConnectionString();
        }
        private void InitFacePic()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            string facePath = Path.Combine(Path.Combine(imagePath, "LoginPage"), "LoginFace.png");
            FacePic.Image = Image.FromFile(facePath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewAccBut_Click(object sender, EventArgs e)
        {
            Hide();
            AccountCreation createAccount = new AccountCreation();
            createAccount.ShowDialog();
            Show();
                     
        }

        private void LoginBut_Click(object sender, EventArgs e)
        {
            //verfy login and hash for password
            if(LoginBox.Text == "" || PasswordBox.Text == "")
            {
                MessageBox.Show("Smth went wrong!", "Mistake!");
                return;
            }

            User user = DBUsage.GetUserInAuthorization(LoginBox.Text, PasswordBox.Text);

            if(!(user is null))//we can enter in account
            {
                PasswordBox.Text = "";
                Hide();
                UserMenu menu = new UserMenu(user);
                menu.ShowDialog();
                Show();
                return;
            }
            MessageBox.Show("Smth went wrong!", "Mistake!");
        }

        private void CheckSubTaskMenu_Click(object sender, EventArgs e)
        {
            TableTask task = new TableTask("firstTask");

/*            SubTask testSubTask = new SubTask("checkTask", 0, 1);

            testSubTask.CheckLists.Add(new CheckListModel("First check List"));
            testSubTask.CheckLists.Last().Cases.Add(new CheckListCase("first"));
            testSubTask.CheckLists.Last().Cases.Add(new CheckListCase("second"));

            testSubTask.CheckLists.Add(new CheckListModel("Second check List"));
            testSubTask.CheckLists.Last().Cases.Add(new CheckListCase("third"));
            testSubTask.CheckLists.Last().Cases.Add(new CheckListCase("fourth "));

            task.SubTasks.Add(testSubTask);*/

            SubTask secondSubTask = new SubTask("second SubTask", 0, 1);
            //secondSubTask.Attachments.Add(new Attachment(1, "sdf"));
            task.SubTasks.Add(secondSubTask);

            Table table = new Table("firstTable");
            table.Tasks.Add(task);

            AddUserInTableTEST(table);

            InitSubTaskToCheckAttAchmentsTEST(table, task, secondSubTask);

            SubTaskMenu menu = new SubTaskMenu(secondSubTask, table, task);
            menu.ShowDialog();
        }

        public void AddUserInTableTEST(Table table)
        {
            List<string> logins = new List<string>()
            {
                "first",
                "second",
                "third",
                "fourth",
                "fifth",
                "sixth"
            };

            for(int i = 0; i < logins.Count; i++)
            {
                User newUser = new User(logins[i], logins[i], i);
                table.UserInTable.Add(newUser);
            }
        }

        public void InitSubTaskToCheckAttAchmentsTEST(Table table, TableTask task, SubTask toAddAttachs)
        {
            List<string> subTasksName = new List<string>()
            {
                "first",
                "okoafouerourgoirgonoefwvoiefvoioksdakeawfkjasdlk;nsadl;dcsall;c,mvcx.mvcx.xcv.,mvxc./xvcz.msd.a,kljfdga",
                ",lpwsx",
                "provmrtmotyomyth",
                "kmfnjdvomdogjdnbiomfegbonjiofmregonjbiembonjirfeigbonjtebnjoigwenbjfijebnitje"
            };

            for(int i = 0; i < subTasksName.Count; i++)
            {
                SubTask newSubTask = new SubTask(subTasksName[i], i + 1, i + 2);
                task.SubTasks.Add(newSubTask);
                toAddAttachs.Attachments.Add(new Attachment(i + 2, subTasksName[i], i));
            }


        }
    }
}
