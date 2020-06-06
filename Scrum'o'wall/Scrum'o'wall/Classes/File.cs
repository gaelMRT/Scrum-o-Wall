/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   File.cs
 * Desc.    :   This file contains the structure of the TaskFile class   
 */

namespace Scrum_o_wall.Classes
{
    public class File
    {
        private readonly int id;
        private int userStoryId;
        private UserStory userStory;


        public File(int id, string name, string description, int userStoryId)
        {
            this.id = id;
            Name = name;
            Description = description;
            this.userStoryId = userStoryId;
        }

        public int Id => id;
        public string Name { get; set; }
        public string Description { get; set; }
        public UserStory UserStory
        {
            get => userStory; set
            {
                userStory = value;
                userStoryId = value.Id;
            }
        }
        public int UserStoryId => userStoryId;

        public override string ToString()
        {
            return Description;
        }
    }
}
