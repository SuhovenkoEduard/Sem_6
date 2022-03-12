using ClassLibrary.Entities;
using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CSV
{
    public class CsvWorking
    {
        public void WriteFile<T>(string path, T item)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                {
                    try
                    {
                        var propArr = item.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

                        string resultString = String.Empty;
                        for (int i = 0; i < propArr.Length; i++)
                        {
                            resultString += propArr[i].GetValue(item);

                            if (i != propArr.Length - 1)
                                resultString += ',';
                        }

                        writer.WriteLine(resultString);
                        fs.Seek(0, SeekOrigin.End);
                    }
                    catch (Exception exc)
                    {
                        throw new Exception(exc.Message);
                    }
                    finally
                    {
                        writer.Close();
                        fs.Close();
                    }
                }
            }
        }

        public IEnumerable<T> ReadFile<T>(string path) where T : IPropertys, new()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs, Encoding.Default))
                {
                    try
                    {
                        List<T> list = new List<T>();

                        string line = String.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var valuesArr = line.Split(',');
                            T item = new T();
                            item.SetValue(valuesArr);

                            list.Add(item);
                            fs.Seek(0, SeekOrigin.End);
                        }
                        return list;
                    }
                    catch (Exception exc)
                    {
                        throw new Exception(exc.Message);
                    }
                    finally
                    {
                        reader.Close();
                        fs.Close();
                    }
                }
            }
        }
    }
}
