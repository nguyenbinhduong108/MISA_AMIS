using AutoMapper.Execution;

namespace MISA.AspNetcore
{
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tổng 2 số nguyên</returns>
        /// Author: NBDUONG (11/08/2023)
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        /// <summary>
        /// Hàm trừ 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Hiệu 2 số nguyên</returns>
        /// Author: NBDUONG (11/08/2023)
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        /// <summary>
        /// Hàm nhân 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tích 2 số nguyên</returns>
        /// Author: NBDUONG (11/08/2023)
        public long Mul(int x, int y)
        {
            return x * (long)y;
        }

        /// <summary>
        /// Hàm chia 2 số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Thương 2 số nguyên</returns>
        /// <exception cref="Exception">Lỗi không thể chia cho 0</exception>
        /// Author: NBDUONG (11/08/2023)
        public double Div(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Không thể chia cho 0");
            }
            return x / (double)y;
        }

        /// <summary>
        /// Hàm tách chuỗi và tính tổng
        /// </summary>
        /// <param name="input">Chuỗi đầu vào</param>
        /// <returns>Tổng các phần tử dương</returns>
        /// <exception cref="ArgumentException">Lỗi khi chuỗi có số âm hoặc có ký tự</exception>
        /// Author: NBDUONG (13/08/2023)
        public int Add(string input)
        {
            int sum = 0;

            if (string.IsNullOrEmpty(input))
                return 0;

            string[] separators = { ",", " " };
            string[] numbers = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string negativeNumbers = "";
            string invalidNumbers = "";

            foreach (string number in numbers)
            {
                if (int.TryParse(number.Trim(), out int num))
                {
                    if (num < 0)
                    {
                        if (!string.IsNullOrEmpty(negativeNumbers))
                        {
                            negativeNumbers += ", ";
                        }
                        negativeNumbers += num.ToString();
                    }
                    else 
                    {
                        sum += num;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(invalidNumbers))
                    {
                        invalidNumbers += ", ";
                    }
                    invalidNumbers += number;
                }

            }

            if (!string.IsNullOrEmpty(negativeNumbers))
            {
                throw new ArgumentException($"Không chấp nhận toán tử âm: {negativeNumbers}");  
            }

            if (!string.IsNullOrEmpty(invalidNumbers))
            {
                throw new ArgumentException($"Giá trị không hợp lệ: {invalidNumbers}");
            }

            return sum;
        }
    }
}
