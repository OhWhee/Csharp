using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TextEditor
    {
        public EventManager events;
        File file;

        public TextEditor() { this.events = new EventManager(); }
        public void openFile(string path)
        {
            this.file = new File(path);
            events.notify("File open", "Открытие файла");
        }
        public void saveFile(string path)
        {
            this.file.write();
            events.notify("File save", "Запись файла");
        }
    }
}
