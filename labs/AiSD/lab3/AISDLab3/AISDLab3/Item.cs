using System;

namespace AISDLab3
{
    public class Item
    {
        public DateTime Date { get; set; }

        public float Float { get; set; }

        public string Str { get; set; }

        public override string ToString() => $"Date: {Date}\t Float: {Float}\t Str: {Str}";
        
        public static int InverseCompare(int result) => result == 0 ? 0 : result == 1 ? -1 : 1;
        
        // У
        public static int CompareToOneKey(Item left, Item right) => InverseCompare(DateTime.Compare(left.Date, right.Date));
        // ВВ
        public static int CompareToTwoKeys(Item left, Item right)
        {
            if (DateTime.Compare(left.Date, right.Date) != 0)
                return DateTime.Compare(left.Date, right.Date);
            if (left.Float.CompareTo(right.Float) != 0)
                return left.Float.CompareTo(right.Float);
            return 0;
        }
        // УУВ
        public static int CompareToThreeKeys(Item left, Item right)
        {
            if (DateTime.Compare(left.Date, right.Date) != 0)
                return InverseCompare(DateTime.Compare(left.Date, right.Date));
            if (left.Float.CompareTo(right.Float) != 0)
                return InverseCompare(left.Float.CompareTo(right.Float));
            return left.Str.CompareTo(right.Str);
        }
    }
}
