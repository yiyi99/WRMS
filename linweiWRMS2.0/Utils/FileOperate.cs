using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0.Utils {
    /// <summary>
    /// 文件操作
    /// </summary>
    class FileOperate {
        /// <summary>
        /// 复制文件到指定目录并修改文件名
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool FileCopy(String from,String to) {
            try {
                File.Copy(from, to);
            } catch (Exception e) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 文件夹的复制
        /// </summary>
        /// <param name="fromDir"></param>
        /// <param name="toDir"></param>
        public bool DirectoryCopy(string fromDir, string toDir){
            try {
                if (!Directory.Exists(fromDir))
                    return false;
                if (!Directory.Exists(toDir)) {
                    Directory.CreateDirectory(toDir);
                }

                string[] fs = Directory.GetFiles(fromDir);
                foreach (string formFileName in fs) {
                    string fileName = Path.GetFileName(formFileName);
                    string toFileName = Path.Combine(toDir, fileName);
                    File.Copy(formFileName, toFileName);
                }
                string[] fromDirs = Directory.GetDirectories(fromDir);
                foreach (string fromDirName in fromDirs) {
                    string dirName = Path.GetFileName(fromDirName);
                    string toDirName = Path.Combine(toDir, dirName);
                    DirectoryCopy(fromDirName, toDirName);
                }
            } catch(Exception e) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String GetFex(String fileName) {
            return fileName.Substring(fileName.LastIndexOf(".")+1);
        }

        /// <summary>
        /// 保存文件位置
        /// </summary>
        /// <returns></returns>
        public String SavePath(int type) {
            switch (type) {
                case 1: return @"Data\project\001\";
                case 2: return @"Data\project\002\";
                case 3: return @"Data\project\003\";
                case 4: return @"Data\project\004\";
                case 5: return @"Data\project\005\";
                case 6: return @"Data\project\006\";
                case 7: return @"Data\project\007\";
                case 8: return @"Data\project\008\";
                case 9: return @"Data\project\009\";
                case 10: return @"Data\project\010\";
            }
            return null;
        }

        /// <summary>
        /// 删除后的文件保存位置
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public String DelPath(int type) {
            switch (type) {
                case 1: return @"Data\dels\001\";
                case 2: return @"Data\dels\002\";
                case 3: return @"Data\dels\003\";
                case 4: return @"Data\dels\004\";
                case 5: return @"Data\dels\005\";
                case 6: return @"Data\dels\006\";
                case 7: return @"Data\dels\007\";
                case 8: return @"Data\dels\008\";
                case 9: return @"Data\dels\009\";
                case 10: return @"Data\dels\010\";
            }
            return null;
        }

        /// <summary>
        /// 检测指定目录下文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool FileExist(String path) {
            if (File.Exists(path)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool MoveFile(String from ,String to) {
            try {
                File.Move(from, to);
            } catch(Exception e) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// C#遍历指定文件夹中的所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public String[] AllFile(String path) {
            DirectoryInfo TheFolder = new DirectoryInfo(path);
            FileInfo[] files=TheFolder.GetFiles();
            int num = files.Length;
            int i = 0;
            String[] fileNames=new String[num];
            foreach(FileInfo file in files){
                if (i < num) {
                    fileNames[i] = file.Name;
                }
                i++;
            }
            return fileNames;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Boolean DeleteFile(String path){
            try {
                File.Delete(path);
            }catch(Exception e){
                return false;
            }
            return true;
        }
    }
}
