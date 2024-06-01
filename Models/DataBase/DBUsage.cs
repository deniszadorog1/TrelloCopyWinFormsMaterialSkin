using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;

using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using TrelloCopyWinForms.Models.TableModels;
using System.Drawing;
using TrelloCopyWinForms.Models.Enums;

namespace TrelloCopyWinForms.Models.DataBase
{
    public static class DBUsage
    {
        private static string _connectionString = "";

        public static void InitConnectionString()
        {
            DotEnv.Load();
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }
        public static void InserUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Users]([Login], [Password], [Email]) VALUES(@login, @password, @email)";

                string passHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@password", passHash);
                command.Parameters.AddWithValue("@email", user.Password);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static bool IfUserParamsExistInDB(string login, string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Login], [Email] FROM [Users] us " +
                    "WHERE EXISTS(SELECT[Login], [Email] FROM[Users] users " +
                    "WHERE us.Login = @login OR us.Email = @email)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = command.ExecuteReader();
                bool check = reader.Read();

                connection.Close();

                return check;
            }
        }
        public static User GetUserInAuthorization(string login, string password)
        {
            User res = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Users] WHERE [Users].Login = @login";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(password, reader["Password"].ToString()))
                    {
                        res = new User(reader["Login"].ToString(),
                            reader["Email"].ToString(), int.Parse(reader["Id"].ToString()));
                        return res;
                    }
                }
                connection.Close();
            }
            return res;
        }
/*        public static Table AddTableByTag(string tag)
        {
            Table res = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Tables]";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(tag, reader["EnterTag"].ToString()))
                    {
                        res = new Table();

                        res.Name = reader["Name"].ToString();
                        if (reader["ColorId"] != DBNull.Value)
                        {
                            res.BgColor = GetColorById(int.Parse(reader["ColorId"].ToString()));
                        }
                        res.Id = int.Parse(reader["id"].ToString());

                        //Init flags
                        List<Flag> flags = GetTagsForTable(res);
                        res._allFlags = flags;

                        //Init Tasks
                        res.Tasks = GetTasksForTable(res.Id);

                        //Init Users
                        res.UserInTable = GetUsersForTable(res.Id);

                        //Init lastSubTask index
                        res.InitLastSubTaskIndex();
                    }
                }


                connection.Close();
            }

            return res;
        }*/
        private static Table GetTableById(int id)
        {
            Table res = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Tables] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    res = new Table();

                    res.Name = reader["Name"].ToString();
                    if (reader["ColorId"] != DBNull.Value)
                    {
                        res.BgColor = GetColorById(int.Parse(reader["ColorId"].ToString()));
                    }
                    res.Id = int.Parse(reader["id"].ToString());

                    //Init flags
                    List<Flag> flags = GetTagsForTable(res);
                    res._allFlags = flags;

                    //Init Tasks
                    res.Tasks = GetTasksForTable(res.Id);

                    //Init Users
                    res.UserInTable = GetUsersForTable(res.Id);

                    //Init lastSubTask index
                    res.InitLastSubTaskIndex();
                }
                connection.Close();
            }

            return res;
        }

        public static bool ComparePassHashes(string login, string oldPassword)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Users] WHERE [Users].Login = @login";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(oldPassword, reader["Password"].ToString()))
                    {
                        return true;
                    }
                }
                connection.Close();
            }
            return false;
        }
        public static void UpdateUser(string oldUserLogin, User userParams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [Users] SET [Login] = @login, [Password] = @password, [Email] = @email WHERE [Login] = @oldLogin";

                string passHash = BCrypt.Net.BCrypt.HashPassword(userParams.Password);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", userParams.Login);
                command.Parameters.AddWithValue("@password", passHash);
                command.Parameters.AddWithValue("@email", userParams.Email);
                command.Parameters.AddWithValue("@oldLogin", oldUserLogin);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertColor(int r, int g, int b)
        {
            if (IfColorContainsInDB(Color.FromArgb(r, g, b))) return;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Color]([R], [G], [B]) VALUES(@r, @g, @b)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", r);
                command.Parameters.AddWithValue("@g", g);
                command.Parameters.AddWithValue("@b", b);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static bool IfColorContainsInDB(Color color)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM [Color] WHERE [R] = @r AND [G] = @g AND [B] = @b";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", color.R);
                command.Parameters.AddWithValue("@g", color.G);
                command.Parameters.AddWithValue("@b", color.B);

                int count = (int)command.ExecuteScalar();

                connection.Close();

                return count != 0 ? true : false;
            }
        }
        public static void InsertCoverPhoto(string path)
        {
            if (IfPhotoPathContainsInDB(path)) return;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [CoverPhoto] ([DirectoryWay]) VALUES (@path)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@path", path);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static bool IfPhotoPathContainsInDB(string path)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM [CoverPhoto] WHERE [DirectoryWay] = @path";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@path", path);

                int count = (int)command.ExecuteScalar();
                return count > 0;

                connection.Close();
            }
        }

        public static void InsertCover(Cover cover)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Cover] ([ColorId], [PhotoId], [TypeId]) VALUES(@colorId, @photoId, @typeId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@colorId", GetColorIdByColor(cover.BGColor));
                command.Parameters.AddWithValue("@PhotoId", GetPhotoIDByPathForCover(cover));
                command.Parameters.AddWithValue("@typeId", GetCoverType(cover));

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static object GetCoverType(Cover cover)
        {
            if (cover is null) return DBNull.Value;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Id] FROM [CoverType] WHERE [Type] = @type";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("type", cover.Type.ToString());

                return int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
            }
            return DBNull.Value;
        }
        public static object GetPhotoIDByPathForCover(Cover cover)
        {
            if (cover.BGImage is null) return DBNull.Value;
            return GetPhotoIdByPath(cover.BGImage.Path);

        }
        public static object GetPhotoIdByPath(string path)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT *  FROM [CoverPhoto] WHERE [DirectoryWay] = @path";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@path", path);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["DirectoryWay"].ToString() == path)
                    {
                        return reader["Id"];
                    }
                }
                connection.Close();
            }
            return DBNull.Value;
        }

        public static object InitPathToImageCover(Cover cover)
        {
            if (!(cover.BGImage is null))
            {
                return cover.BGImage.Path;
            }
            return DBNull.Value;
        }

        public static object GetColorIdByColor(Color? color)
        {
            if (color is null) return DBNull.Value;
            int res = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT [Id] FROM [Color] WHERE [R] = @r AND [G] = @g AND [B] = @b";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", ((Color)color).R);
                command.Parameters.AddWithValue("@g", ((Color)color).G);
                command.Parameters.AddWithValue("@b", ((Color)color).B);

                res = int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
            }
            return res;
        }

        public static void InsertTable(Table table)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Tables]([Name], [ColorId]) VALUES(@name, @colorId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", table.Name);
                command.Parameters.AddWithValue("@colorId", GetColorId(table));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void InsertTask(TableTask task)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Tasks]([Name], [TableId], [PlaceInTableId]) VALUES (@name, @tableId, @placeInTable)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", task.Name);
                command.Parameters.AddWithValue("@tableId", GetTableId(task));
                command.Parameters.AddWithValue("@placeInTable", task.PlaceingTableId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static int GetTableId(TableTask task)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Id] FROM [Tables] WHERE [Id] = @tableId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("tableId", task.TableId);

                return int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
            }
        }
        public static object GetColorId(Table table)
        {
            if (table.BgColor is null) return DBNull.Value;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Id] FROM [Color] WHERE [R] = @r AND [G] = @g AND [B] = @b";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", ((Color)table.BgColor).R);
                command.Parameters.AddWithValue("@g", ((Color)table.BgColor).G);
                command.Parameters.AddWithValue("@b", ((Color)table.BgColor).B);

                return int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
            }
        }
        public static void InsertSubTask(SubTask subTask)
        {
            using (SqlConnection connenction = new SqlConnection(_connectionString))
            {
                connenction.Open();

                string query = "INSERT INTO [SubTask]([Name], [TaskId], [Description], [PlaceInTask], [SubTaskIdOnTable], [StartDate], [DeadLine], [CoverId]) " +
                    "VALUES(@name, @taskId, @description, @placeInTask, @globalId, @startDate, @DeadLine, @coverId)";

                SqlCommand command = new SqlCommand(query, connenction);
                command.Parameters.AddWithValue("@name", subTask.Name);
                command.Parameters.AddWithValue("@taskId", subTask.TaskId);
                command.Parameters.AddWithValue("@description", subTask.Description);
                command.Parameters.AddWithValue("@placeInTask", subTask.UniqueIndex);
                command.Parameters.AddWithValue("@globalId", subTask.GlobalSubTaskIndex);
                command.Parameters.AddWithValue("@startDate", GetStartDateForSubTask(subTask));
                command.Parameters.AddWithValue("@Deadline", GetEndDateForSubTask(subTask));
                command.Parameters.AddWithValue("@coverId", GetCoverIdForSubTask(subTask));

                command.ExecuteNonQuery();

                connenction.Close();
            }
        }
        public static object GetCoverIdForSubTask(SubTask subTask)
        {
            if (subTask.Cover is null) return DBNull.Value;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELCET [Id] FROM [Cover] WHERE " +
                    "[ColorId] = @colorId AND [PhotoId] = @photoId AND [TypeId] = @typeId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@colorID", GetColorIdForSubTask(subTask));
                command.Parameters.AddWithValue("@photoId", GetPhotoIdForSUbTask(subTask));
                command.Parameters.AddWithValue("@typeId", GetCoverType(subTask.Cover));

                connection.Close();
            }
            return DBNull.Value;
        }
        public static object GetPhotoIdForSUbTask(SubTask subTask)
        {
            if (subTask.Cover.BGImage is null) return DBNull.Value;
            return GetPhotoIdByPath(subTask.Cover.BGImage.Path);
        }
        public static object GetColorIdForSubTask(SubTask subTask)
        {
            if (subTask.Cover.BGColor is null) return DBNull.Value;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Id] FROM [Color] WHERE [R] = @r AND [G] = @g AND [B] = @b";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", ((Color)subTask.Cover.BGColor).R);
                command.Parameters.AddWithValue("@g", ((Color)subTask.Cover.BGColor).G);
                command.Parameters.AddWithValue("@b", ((Color)subTask.Cover.BGColor).B);

                return int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
            }
        }
        public static object GetStartDateForSubTask(SubTask subTask)
        {
            if (subTask.DeadLine is null || subTask.DeadLine.StartDate is null) return DBNull.Value;
            return subTask.DeadLine.StartDate;
        }
        public static object GetEndDateForSubTask(SubTask subTask)
        {
            if (subTask.DeadLine is null || subTask.DeadLine.EndDate is null) return DBNull.Value;
            return subTask.DeadLine.EndDate;
        }

        public static void InsertTags(Table table, Flag flag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Tag]([TableId], [ColorId], [Text]) " +
                    "VALUES(@tableId, @colorId, @text)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", table.Id);
                command.Parameters.AddWithValue("@colorId", GetColorIdByColor(flag.FlagColor));
                command.Parameters.AddWithValue("@text", flag.FlagTag);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertSubTaskTag(SubTask subTask, Flag flag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [SubtaskTag]([SubtaskID], [TagId]) VALUES(@subTaskId, @tagId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTask.Id);
                command.Parameters.AddWithValue("@tagId", flag.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertUserTables(Table table, User user, AccountType type)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [UsersTable] ([UserId], [TableId], [UserTypeId]) VALUES(@userId, @tableId, @typeId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@tableId", table.Id);
                command.Parameters.AddWithValue("@typeId", GetTypeIdByUserType(type));

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static int GetTypeIdByUserType(AccountType type)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Id] FROM [Type] WHERE [Type] = @type";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@type", type.ToString());

                return (int)command.ExecuteScalar();


                connection.Close();
            }
        }

        public static void InsertUserSubTask(int userId, SubTask subtask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [SubTaskParticipants] ([UserId], [SubtaskId]) VALUES(@userId, @subTaskId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@subTaskId", subtask.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void InsertHistoryMessage(Comment message, SubTask subTask, User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [SubTaskChangingHistory]([subtaskId], [ActionDate], [UserId], [Text], [IndexInHistory]) " +
                    "VALUES(@taskId, @actionDate, @userId, @text, @indexInHistory)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@taskId", subTask.Id);
                command.Parameters.AddWithValue("@actionDate", message.Date);
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@text", message.Value);
                command.Parameters.AddWithValue("@indexInHistory", message.UniqueIndex);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertCommentMessage(Comment message, SubTask subtask, User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Comments]([subtaskId], [ActionDate], [UserId], [Text], [IndexInHistory]) " +
                    "VALUES(@taskId, @actionDate, @userId, @text, @indexInHistory)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@taskId", subtask.Id);
                command.Parameters.AddWithValue("@actionDate", message.Date);
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@text", message.Value);
                command.Parameters.AddWithValue("@indexInHistory", message.UniqueIndex);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertCheckList(CheckListModel checkList, SubTask subtask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [CheckList]([SubTaskId], [Name], [LineParam]) " +
                    "VALUES(@subtaskId, @name, @lineParam)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subtaskId", subtask.Id);
                command.Parameters.AddWithValue("@name", checkList.Name);
                command.Parameters.AddWithValue("@lineParam", checkList.LineParam);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void DeleteFromUserSubTask(int userId, SubTask subTask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [SubTaskParticipants] WHERE [UserId] = @userId AND [SubtaskId] = @subTaskId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@subTaskId", subTask.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void UpdateCheckList(CheckListModel model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [CheckList] SET [SubTaskId] = @subTaskId, " +
                    "[Name] = @name, [LineParam] = @linePar WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@subTaskId", model.SubTaskId);
                command.Parameters.AddWithValue("@name", model.Name);
                command.Parameters.AddWithValue("@linePar", model.LineParam);
                command.Parameters.AddWithValue("@id", model.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertCheckListCase(CheckListCase listCase, CheckListModel model, SubTask subtask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [CheckListParam]([Name], [CheckListId], [SubTaskId], [Status]) " +
                    "VALUES(@name, @listId, @subTaskId, @ststus)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", listCase.Name);
                command.Parameters.AddWithValue("@listId", model.Id);
                command.Parameters.AddWithValue("@subTaskId", subtask.Id);
                command.Parameters.AddWithValue("@ststus", listCase.IfCaseDone ? 1 : 0);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static List<Table> GetAllTables()
        {
            List<Table> res = new List<Table>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Tables]";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Table table = new Table();

                    table.Name = reader["Name"].ToString();
                    if (reader["ColorId"] != DBNull.Value)
                    {
                        table.BgColor = GetColorById(int.Parse(reader["ColorId"].ToString()));
                    }
                    table.Id = int.Parse(reader["id"].ToString());

                    //Init flags
                    List<Flag> flags = GetTagsForTable(table);
                    table._allFlags = flags;

                    //Init Tasks
                    table.Tasks = GetTasksForTable(table.Id);

                    //Init Users
                    table.UserInTable = GetUsersForTable(table.Id);

                    //Init lastSubTask index
                    table.InitLastSubTaskIndex();

                    res.Add(table);
                }

                connection.Close();
            }
            return res;
        }
        public static List<User> GetUsersForTable(int tableId)
        {
            List<User> res = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [UsersTable] WHERE [TableId] = @tableId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = GetUserById((int)reader["UserId"]);
                    res.Add(user);
                }
                connection.Close();
            }

            return res;
        }
        private static User GetUserById(int userId)
        {
            User res = new User();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Users] WHERE [Id] = @userId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Id = (int)reader["Id"];
                    res.Login = reader["Login"].ToString();
                    res.Email = reader["Email"].ToString();
                }

                connection.Close();
                return res;
            }
        }
        private static List<TableTask> GetTasksForTable(int tableId)
        {
            List<TableTask> tasks = new List<TableTask>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Tasks] WHERE [TableId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", tableId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TableTask task = new TableTask();
                    task.Id = int.Parse(reader["Id"].ToString());
                    task.Name = reader["Name"].ToString();
                    task.PlaceingTableId = int.Parse(reader["PlaceInTableId"].ToString());

                    //Init subTasks for task
                    task.SubTasks = GetSubTasksForTask(task.Id);

                    tasks.Add(task);
                }

                connection.Close();
            }
            return tasks;
        }
        private static List<SubTask> GetSubTasksForTask(int taskId)
        {
            List<SubTask> res = new List<SubTask>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [SubTask] WHERE [TaskId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", taskId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SubTask subTask = new SubTask();

                    subTask.Id = int.Parse(reader["Id"].ToString());
                    subTask.Name = reader["Name"].ToString();
                    subTask.Description = reader["Description"].ToString();
                    subTask.UniqueIndex = int.Parse(reader["PlaceInTask"].ToString());
                    subTask.GlobalSubTaskIndex = int.Parse(reader["SubTaskIdOnTable"].ToString());
                    subTask.DeadLine = InitDateInSubTask(reader["StartDate"], reader["DeadLine"], reader["IfDone"]);
                    subTask.Cover = GetCoverById(reader["CoverId"]);
                    subTask.TaskId = (int)reader["TaskId"];
                    //HIstory
                    subTask.History = GetHistoryForSubTask(subTask.Id);

                    //Comments
                    subTask.Comments = GetCommentsForSubTask(subTask.Id);

                    //Flags
                    subTask.Flags = GetFlagsForSubTask(subTask.Id);

                    //Attachments 
                    subTask.Attachments = GetAttachmentsForSubTask(subTask.Id);

                    //User Ids on subtask
                    subTask.UsersIdsInSuBTask = GetUserIdsForSubTask(subTask.Id);

                    subTask.CheckLists = GetCehckLists(subTask.Id);

                    res.Add(subTask);
                }
                connection.Close();
            }

            return res;
        }
        private static List<CheckListModel> GetCehckLists(int subtaskId)
        {
            List<CheckListModel> res = new List<CheckListModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [CheckList] WHERE [SubTaskId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subtaskId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CheckListModel model = new CheckListModel();
                    model.Name = reader["Name"].ToString();
                    model.SubTaskId = (int)reader["SubTaskId"];
                    model.Id = (int)reader["Id"];
                    model.LineParam = (int)reader["LineParam"];

                    model.Cases = GetCheckListCases(model.Id);

                    res.Add(model);
                }
                connection.Close();
            }

            return res;
        }
        private static List<CheckListCase> GetCheckListCases(int checkListId)
        {
            List<CheckListCase> res = new List<CheckListCase>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [CheckListParam] WHERE [CheckListId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", checkListId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CheckListCase model = new CheckListCase();

                    model.Name = reader["Name"].ToString();
                    model.ListId = (int)reader["CheckListId"];
                    model.Id = (int)reader["Id"];
                    model.IfCaseDone = (bool)reader["Status"];

                    res.Add(model);
                }
                connection.Close();
            }
            return res;
        }
        public static void UpdateCheckListCase(CheckListModel model, CheckListCase listCase)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [CheckListParam] SET [Name] = @name, " +
                    "[CheckListId] = @checkListId, [Status] = @status WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", listCase.Name);
                command.Parameters.AddWithValue("@checkListId", listCase.ListId);
                command.Parameters.AddWithValue("@status", listCase.IfCaseDone);
                command.Parameters.AddWithValue("@id", listCase.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static List<Attachment> GetAttachmentsForSubTask(int subTaskId)
        {
            List<Attachment> res = new List<Attachment>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Attachments] WHERE [SubTaskPlaceingId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTaskId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Attachment attachment = new Attachment();

                    attachment.Sign = reader["Sign"].ToString();
                    attachment.Id = int.Parse(reader["Id"].ToString());
                    attachment.UniqueIndex = int.Parse(reader["IdInSubTaskAttachs"].ToString());
                    attachment.SubTaskGlobalIndex = int.Parse(reader["IdOnTable"].ToString());
                    attachment.SubTaskPlacingId = int.Parse(reader["SubTaskPlaceingId"].ToString());
                    attachment.SubTaskLinkId = int.Parse(reader["SubTaskLinkingId"].ToString());

                    res.Add(attachment);
                }

                connection.Close();
            }

            return res;
        }
        private static List<int> GetUserIdsForSubTask(int subTaskId)
        {
            List<int> res = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [SubTaskParticipants] WHERE [SubtaskId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTaskId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(int.Parse(reader["UserId"].ToString()));
                }
                connection.Close();
            }
            return res;
        }
        private static List<Flag> GetFlagsForSubTask(int subTaskId)
        {
            List<Flag> res = new List<Flag>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [SubtaskTag] WHERE [SubtaskID] = @subTaskId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTaskId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int flagId = int.Parse(reader["TagId"].ToString());
                    Flag flag = GetFlagByFlagId(flagId);
                    res.Add(flag);
                }
                connection.Close();
            }
            return res;
        }
        public static void InsertAttachment(Attachment newAttch)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [Attachments]([Sign], [IdInSubTaskAttachs], [IdOnTable], [SubTaskPlaceingId], [SubTaskLinkingId]) " +
                    "VALUES(@sign, @uniqueIndex, @SubTaskGlobalIndex, @subTaskPlacingId, @subTaskLinkingId)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@sign", newAttch.Sign);
                command.Parameters.AddWithValue("@uniqueIndex", newAttch.UniqueIndex);
                command.Parameters.AddWithValue("@SubTaskGlobalIndex", newAttch.SubTaskGlobalIndex);
                command.Parameters.AddWithValue("@subTaskPlacingId", newAttch.SubTaskPlacingId);
                command.Parameters.AddWithValue("@subTaskLinkingId", newAttch.SubTaskLinkId);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void DeleteAttachmnet(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Attachments WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static Flag GetFlagByFlagId(int flagId)
        {
            Flag res = new Flag();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Tag] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", flagId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Id = int.Parse(reader["Id"].ToString());
                    res.FlagTag = reader["Text"].ToString();
                    res.FlagColor = (Color)GetColorById(int.Parse(reader["ColorId"].ToString()));
                }
                connection.Close();
            }
            return res;
        }

        private static List<Comment> GetCommentsForSubTask(int subTaskId)
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Comments] WHERE [SubtaskId] = @subTaskId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTaskId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Comment commentMessage = new Comment();

                    commentMessage.Id = int.Parse(reader["Id"].ToString());
                    commentMessage.Date = (DateTime)reader["ActionDate"];
                    commentMessage.Value = reader["Text"].ToString();
                    commentMessage.UniqueIndex = int.Parse(reader["IndexInHistory"].ToString());
                    commentMessage.UserId = int.Parse(reader["UserId"].ToString());

                    comments.Add(commentMessage);
                }

                connection.Close();
            }
            return comments;
        }
        private static List<Comment> GetHistoryForSubTask(int subTaskId)
        {
            List<Comment> history = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [SubTaskChangingHistory] WHERE [SubtaskId] = @subTaskId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTaskId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Comment historyMessage = new Comment();

                    historyMessage.Id = int.Parse(reader["Id"].ToString());
                    historyMessage.Date = (DateTime)reader["ActionDate"];
                    historyMessage.Value = reader["Text"].ToString();
                    historyMessage.UniqueIndex = int.Parse(reader["IndexInHistory"].ToString());
                    historyMessage.UserId = int.Parse(reader["UserId"].ToString());

                    history.Add(historyMessage);
                }

                connection.Close();
            }
            return history;
        }

        private static Cover GetCoverById(object coverId)
        {
            if (coverId == DBNull.Value) return null;
            int id = int.Parse(coverId.ToString());
            Cover cover = new Cover();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Cover] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cover.BGColor = GetColorForCover(reader["ColorId"]);
                    cover.BGImage = GetImageAttribsForCoverByPhotoId(reader["PhotoId"]);

                    object coverTypeOBJ = GetCoverTypeObjectById(reader["TypeId"]);
                    cover.Type = GetCoverType(coverTypeOBJ);
                }

                connection.Close();
            }
            return cover;
        }
        private static object GetCoverTypeObjectById(object coverTypeId)
        {
            if (coverTypeId == DBNull.Value) return null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [CoverType] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", int.Parse(coverTypeId.ToString()));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return reader["Type"].ToString();
                }

                connection.Close();
            }
            return DBNull.Value;
        }
        private static CoverType? GetCoverType(object typeInString)
        {
            if (typeInString == DBNull.Value)
            {
                return null;
            }

            for (int i = 0; i <= (int)CoverType.PartSizeCover; i++)
            {
                if (((CoverType)i).ToString() == typeInString.ToString())
                {
                    return (CoverType)i;
                }
            }
            return null;
        }

        private static CoverImageAttributes GetImageAttribsForCoverByPhotoId(object photoId)
        {
            if (photoId == DBNull.Value) return null;

            CoverImageAttributes res = new CoverImageAttributes();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [CoverPhoto] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", int.Parse(photoId.ToString()));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Path = reader["DirectoryWay"].ToString();
                    res.Image = Image.FromFile(res.Path);
                }

                connection.Close();
            }
            return res;
        }



        private static Color? GetColorForCover(object colorId)
        {
            if (colorId == DBNull.Value) return null;

            return GetColorById(int.Parse(colorId.ToString()));
        }
        private static DeadLineDate InitDateInSubTask(object start, object end, object ifDone)
        {
            DeadLineDate deadLint = new DeadLineDate();

            if (start == DBNull.Value &&
                end == DBNull.Value) return null;

            if (end != DBNull.Value) deadLint.EndDate = (DateTime)end;
            if (start != DBNull.Value) deadLint.StartDate = (DateTime)end;

            string str = "";
            if (!(deadLint.StartDate is null))
            {
                str += deadLint.StartDate.ToString() + " - ";
            }
            if (!(deadLint.EndDate is null))
            {
                str += deadLint.EndDate.ToString();
            }
            deadLint.PrintString = str;
            deadLint.IfDone = (bool)ifDone;

            return deadLint;
        }

        private static List<Flag> GetTagsForTable(Table table)
        {
            List<Flag> res = new List<Flag>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Tag] WHERE [TableId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", table.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Flag flag = new Flag();

                    flag.Id = int.Parse(reader["Id"].ToString());
                    flag.FlagTag = reader["Text"].ToString();
                    flag.FlagColor = (Color)GetColorById(int.Parse(reader["ColorId"].ToString()));

                    res.Add(flag);
                }
                connection.Close();
            }
            return res;
        }

        public static void UpdateSubTask(SubTask subTask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [SubTask] SET [Name] = @name, [TaskId] = @taskId, [Description] = @desc, " +
                    "[PlaceInTask] = @placeInTask, [SubTaskIdOnTable] = @subTaskOnTable, [StartDate] = @startDate, " +
                    "[DeadLine] = @endDate, [CoverId] = @coverId, [IfDone] = @ifDone WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", subTask.Name);
                command.Parameters.AddWithValue("@taskId", subTask.TaskId);
                command.Parameters.AddWithValue("@desc", subTask.Description);
                command.Parameters.AddWithValue("@placeInTask", subTask.UniqueIndex);
                command.Parameters.AddWithValue("@subTaskOnTable", subTask.GlobalSubTaskIndex);

                command.Parameters.AddWithValue("@startDate", GetStartTime(subTask.DeadLine));
                command.Parameters.AddWithValue("@endDate", GetEndTime(subTask.DeadLine));
                command.Parameters.AddWithValue("@ifDone", IfDaeadLineIsDone(subTask));

                command.Parameters.AddWithValue("@coverId", GetCoverId(subTask));


                command.Parameters.AddWithValue("@id", subTask.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                }
                connection.Close();
            }
        }
        private static object IfDaeadLineIsDone(SubTask subTask)
        {
            if (subTask is null || subTask.DeadLine is null) return DBNull.Value;
            return subTask.DeadLine.IfDone;
        }
        public static void UpdateCover(Cover cover)
        {
            if (cover is null) return;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [Cover] Set [ColorId] = @colorId, [PhotoId] = @photoId, [TypeId] = @typeId WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@colorId", GetColorIdByColor(cover.BGColor)); ;
                command.Parameters.AddWithValue("@photoId", GetPhotoIDByPathForCover(cover));
                command.Parameters.AddWithValue("@typeId", GetCoverType(cover));
                command.Parameters.AddWithValue("@id", cover.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void UpdateComment(Comment comment)
        {
            if (comment is null) return;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [Comments] Set [SubtaskId] = @subTaskId, " +
                    "[ActionDate] = @date, [UserId] = @userId, " +
                    "[Text] = @text, [IndexInHistory] = @indexInHist  WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@subTaskId", comment.SubTaskId);
                command.Parameters.AddWithValue("@date", comment.Date);
                command.Parameters.AddWithValue("@userId", comment.UserId);
                command.Parameters.AddWithValue("@text", comment.Value);
                command.Parameters.AddWithValue("@indexInHist", comment.UniqueIndex);
                command.Parameters.AddWithValue("@id", comment.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void DeleteComment(Comment comment)
        {
            if (comment is null) return;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE [Comments] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", comment.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void DeleteCoversWhichDoesntContainsInSubTasks()
        {
            List<int> usingCoverIds = new List<int>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [CoverId] FROM [SubTask] WHERE [CoverId] IS NOT NULL";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nullValue", DBNull.Value);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usingCoverIds.Add((int)reader["CoverId"]);
                }

                DeleteCoverWithGivenId(usingCoverIds);
                connection.Close();
            }
        }
        private static void DeleteCoverWithGivenId(List<int> ids)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string idList = string.Join(",", ids);
                string query = $"DELETE FROM [Cover] WHERE [Id] NOT IN ({idList})";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static object GetCoverId(SubTask subTask)
        {
            if (subTask.Cover is null || subTask.Cover.Id == 0) return DBNull.Value;
            return subTask.Cover.Id;
        }
        public static void DeleteSubTask(SubTask subTask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [SubTask] WHERE [@Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTask);

                command.ExecuteNonQuery();

                DeleteFromSubTaskParticipants(subTask.Id);
                DeleteFromSubTaskTag(subTask.Id);
                DeleteAttachment(subTask.Id);

                DeleteComments(subTask.Id);
                DeleteFromHistoryTable(subTask.Id);

                DeleteFromCheckList(subTask.Id);
                DeleteFromCheckListParam(subTask.Id);
                connection.Close();
            }
        }
        private static void DeleteFromCheckListParam(int subTaskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [CheckListParam] WHERE [SubTaskId] = @subTaskId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTaskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteFromCheckList(int subTaskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [CheckList] WHERE [SubTaskId] = @subTaskId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTaskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteFromHistoryTable(int subTaskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [SubTaskChangingHistory] WHERE [SubtaskId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTaskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteComments(int subTaskId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();

                string query = "DELETE FROM [Comments] WHERE [SubtaskId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTaskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteAttachment(int subTaskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [Attachments] WHERE " +
                    "[SubTaskPlaceingId] = @id OR [SubTaskLinkingId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTaskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteFromSubTaskTag(int subtaskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [SubtaskTag] WHERE [SubtaskID] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subtaskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteFromSubTaskParticipants(int subTaskId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM [SubTaskParticipants] WHERE [SubtaskId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTaskId);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static object GetStartTime(DeadLineDate deadLine)
        {
            if (deadLine is null || deadLine.StartDate is null) return DBNull.Value;
            return deadLine.StartDate;
        }
        private static object GetEndTime(DeadLineDate deadLine)
        {
            if (deadLine is null || deadLine.EndDate is null) return DBNull.Value;
            return deadLine.EndDate;
        }

        private static Color? GetColorById(int colorID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Color] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", colorID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int r = int.Parse(reader["R"].ToString());
                    int g = int.Parse(reader["G"].ToString());
                    int b = int.Parse(reader["B"].ToString());

                    return Color.FromArgb(r, g, b);
                }
                connection.Close();
            }
            return null;
        }

        public static void DeleteCheckListParam(CheckListCase checkListCase)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [CheckListParam] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", checkListCase.Id);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void DeleteCheckList(CheckListModel model)
        {
            DeleteCheckListParamsFromCheckList(model.Id);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [CheckList] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", model.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        private static void DeleteCheckListParamsFromCheckList(int checkListId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [CheckListParam] WHERE [CheckListId] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", checkListId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void DeleteTagFromSubTask(SubTask subTask, Flag flag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [SubtaskTag] WHERE [SubtaskID] = @subTaskId AND [TagId] = @tagID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subTaskId", subTask.Id);
                command.Parameters.AddWithValue("@tagID", flag.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void UpdateTask(TableTask task)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [Tasks] SET [Name] = @name, [PlaceInTableId] = @placeID " +
                    "WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", task.Id);
                command.Parameters.AddWithValue("@name", task.Name);
                command.Parameters.AddWithValue("@placeID", task.PlaceingTableId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void DeleteCover(SubTask subTask)
        {
            if (subTask.Cover is null) return;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [Cover] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", subTask.Cover.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static int GetSubTasksLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [SubTask] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;
            }
        }
        public static int GetTaskLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [Tasks] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;

            }
        }
        public static int GetTableLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [Tables] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;

            }
        }
        public static int GetCheckListLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [CheckList] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;
            }
        }
        public static int GetCheckListCaseLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [CheckListParam] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;
            }
        }
        public static int GetUsersLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [Users] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;
            }
        }
        public static int GetTagLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [Tag] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;
            }
        }
        public static int GetCoverLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 [Id] FROM [Cover] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);

                int res = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return res;
            }
        }
        public static int GetLastAttachmentId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 [Id] FROM [Attachments] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);
                int res = int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
                return res;
            }
        }
        public static int GetLastCommentId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 [Id] FROM [Comments] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);
                int res = int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
                return res;
            }
        }
        public static int GetLastHistoryId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 [Id] FROM [SubTaskChangingHistory] ORDER BY [Id] DESC";

                SqlCommand command = new SqlCommand(query, connection);
                int res = int.Parse(command.ExecuteScalar().ToString());

                connection.Close();
                return res;
            }
        }
        public static AccountType? GetUserTypeForTable(int tableId, int userId)
        {
            AccountType? type = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [UsersTable] WHERE [UserId] = @userId AND [TableId] = @tableId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@tableId", tableId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return GetTypeById((int)reader["UserTypeId"]);
                }

                connection.Close();
            }
            return type;
        }

        private static AccountType? GetTypeById(int typeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Type] WHERE [Id] = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", typeId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return GetTypeByString(reader["Type"].ToString());
                }

                connection.Close();
            }
            return null;
        }
        private static AccountType GetTypeByString(string type)
        {
            for (int i = 0; i <= (int)AccountType.Viewer; i++)
            {
                if (((AccountType)i).ToString() == type)
                {
                    return (AccountType)i;
                }
            }
            return AccountType.Viewer;
        }
        public static void AddCodeToAddUser(int tableId, string key, AccountType type)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [AddTableUserTypeKey]([TableId], [TypeId], [Key]) VALUES (@tableId, @typeId, @key)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);
                command.Parameters.AddWithValue("@typeId", GetTypeIdByUserType(type));
                command.Parameters.AddWithValue("@key", key);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static bool IfCodeExist(string code)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM [AddTableUserTypeKey] WHERE [Key] = @code";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@code", code);

                int count = (int)command.ExecuteScalar();
                return count > 0;

                // connection.Close();
            }
        }
        public static void DeleteCodesInTable(int tableId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [AddTableUserTypeKey] WHERE [TableId] = @tableId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Table GetTableByCode(string code)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [TableId] FROM [AddTableUserTypeKey] WHERE [Key] = @key";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@key", code);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int tableId = (int)reader["TableId"];

                    return GetTableById(tableId);
                }


                connection.Close();
            }
            return null;
        }
        public static bool IfUserContainsInTable(int tableId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM [UsersTable] WHERE [UserId] = @userId AND [TableId] = @tableId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@tableId", tableId);

                int count = (int)command.ExecuteScalar();
                return count > 0;
                
            }
        }
        public static void DeleteUserFromUsersTable(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [UsersTable] WHERE [UserId] = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", userId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void MakeUserAnAdminInTable(int tableId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1[UserId] FROM [UsersTable] WHERE [TableId] = @tableId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);

                MakeUserAnAdmin(tableId, (int)command.ExecuteScalar());

                connection.Close();
            }
        }
        private static void MakeUserAnAdmin(int tableId, int userId)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [UsersTable] SET [UserTypeId] = @typeId WHERE [TableId] = @tableId AND [UserId] = @userId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@typeId", 1);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static AccountType GetTypeByCode(string key)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [TypeId] FROM [AddTableUserTypeKey] WHERE [Key] = @key";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@key", key);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int typeId = (int)reader["TypeId"];

                    return (AccountType)GetTypeById(typeId);
                }

                connection.Close();
            }
            return AccountType.Viewer;
        }
        public static AccountType InitUserTypeToUser(int userId, int tableId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [UserTypeId] FROM [UsersTable] WHERE [TableId] = @tableId AND [UserId] = @userId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);
                command.Parameters.AddWithValue("@userId", userId);

                return  (AccountType)GetTypeById((int)command.ExecuteScalar());

                //connection.Close();
            }
        }


    }
}
