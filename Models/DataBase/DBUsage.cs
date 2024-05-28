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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Color] VALUES([R], [G], [B]) VALUES(@r, @g, @b)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", r);
                command.Parameters.AddWithValue("@g", g);
                command.Parameters.AddWithValue("@b", b);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertCoverPhoto(string path)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [CoverPhoto] VALUES([DirectoryWay]) VALUES(@path)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@path", path);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void InsertCover(Cover cover)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Cover] VALUES([ColorId], [PhotoId], [TypeId]) VALUES(@colorId, @photoId, @typeId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@colorId", GetColorIdByColor(cover.BGColor));
                command.Parameters.AddWithValue("@PhotoId", GetPhotoIDByPathForCover(cover));
                command.Parameters.AddWithValue("@typeId", GetCoverType(cover));

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static object GetCoverType(Cover cover)
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

        public static int? GetColorIdByColor(Color? color)
        {
            if (color is null) return null;
            int res = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT [Id] FROM [Color] WHERE [R] = @r AND [G] = @g AND [B] = @b";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@r", ((Color)color).R);
                command.Parameters.AddWithValue("@g", ((Color)color).G);
                command.Parameters.AddWithValue("@b", ((Color)color).B);

                SqlDataReader reader = command.ExecuteReader();
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

                string query = "INSER INTO [Tasks]([Name], [TableId]) VALUES (@name, @tableId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", task.Name);
                command.Parameters.AddWithValue("@tableId", GetTableId(task));

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
                command.Parameters.AddWithValue("tableId", task.PlaceingTableId);

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

                string query = "SELECT [Id] FROM [Colors] WHERE [R] = @r AND [G] = @g AND [B] = @b";

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

            using (SqlConnection connection = new SqlConnection())
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

                string query = "SELECT [Id] FROM [Colors] WHERE [R] = @r AND [G] = @g AND [B] = @b";

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
        public static void InsertSubTaskFlag(SubTask subTask, Flag flag)
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

        public static void InsertUserTables(Table table, User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [UsersTable] ([UserId], [TableId]) VALUES(@userId, @tableId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@tableId", table.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void InsertUserSubTask(User user, SubTask subtask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSER INTO [SubTaskParticipants] ([UserId], [SubtaskId]) VALUES(@userId, @subTaskId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", user.Id);
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

                string query = "INSERT INTO [SubTaskChangingHistory]([subtaskId], [ActionDate], [UserId], [Text]) " +
                    "VALUES(@taskId, @actionDate, @userId, @text)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@taskId", subTask.Id);
                command.Parameters.AddWithValue("@actionDate", message.Date);
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@text", message.Value);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InsertCommentMessage(Comment message, SubTask subtask, User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Comments]([subtaskId], [ActionDate], [UserId], [Text]) " +
                    "VALUES(@taskId, @actionDate, @userId, @text)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@taskId", subtask.Id);
                command.Parameters.AddWithValue("@actionDate", message.Date);
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@text", message.Value);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void InitCheckList(CheckListModel checkList, SubTask subtask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [CheckList]([SubTaskId], [Name]) " +
                    "VALUES(@subtaskId, @name)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subtaskId", subtask.Id);
                command.Parameters.AddWithValue("@name", checkList.Name);

                connection.Close();
            }
        }
        public static void InitCheckList(CheckListCase listCase, SubTask subtask)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [CheckListParam]([Name], [CheckListId], [SubTaskId], [Status]) " +
                    "VALUES(@name, @listId, @subTaskId, @ststus)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", listCase.Name);
                command.Parameters.AddWithValue("@listId", listCase.ListId);
                command.Parameters.AddWithValue("@subTaskId", subtask.Id);
                command.Parameters.AddWithValue("@ststus", listCase.IfCaseDone ? 1 : 0);

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

                    //Init flags
                    //Init Tasks
                    //Init Users
                    //Init other stuff

                }

                connection.Close();
            }
            return res;
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
    }
}
