using System;

namespace CodeBasic
{
    public class RankCards
    {
         /// <summary>
        /// หน้าไพ่
        /// 1 => ป๊อก 9
        /// 2 => ป๊อก 8
        /// 3 => ตอง
        /// 4 => ผี
        /// 5 => เรียง
        /// 6 => ไพ่ธรรมดา
        /// </summary>
        public int RankCard { get; set; }
        /// <summary>
        /// แต้ม
        /// </summary>
        public int Point { get; set; }
    }
}
