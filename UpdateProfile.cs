using General;

namespace UpdateProfile
{
    class UpdateInfo
    {
        GeneralMethod generalMethod = new GeneralMethod();
        private bool isNumString(string s){
            long test;
            //kiểm tra xem có phải chuỗi chỉ toàn số hay không?
            return long.TryParse(s,out test);
        }
        private void noti(string s){
            Console.Clear();
            Console.SetCursorPosition(0,5);
            Console.WriteLine(s + "\nNhấn phím bất kỳ để tiếp tục");
            Console.ReadKey();
        }
        public void printBang(NhanVien account)
        {
            string[] gt ={"Nữ","Nam"};
            Console.Clear();
            Console.WriteLine(
                        " ----------------------------------------\n" +
                        "|Mã nhân viên:{0,-27}|\n" +
                        "|Username:{1,-31}|\n" +
                        "|1. password:{2,-28}|\n" +
                        "|2. Tên nhân viên:{3,-23}|\n" +
                        "|3. Ngày tháng năm sinh:{4,-17}|\n" +
                        "|4. Giới tính:{5,-27}|\n" +
                        "|5. CCCD:{6,-32}|\n" +
                        "|6. SDT:{7,-33}|\n" +
                        "|7. Xác nhận{8,-29}|\n" +
                        " ----------------------------------------\n",
                    account.IdNhanVien, account.UserName, account.PassWord, account.TenNhanVien, account.BirthDay, gt[account.GioiTinh], account.CCCD
                    , account.SDT,""

    );

        }
        public string inputPassWord(NhanVien account)
        {
            //tạo biến để nhập pass mới
            string pass;
            // tạo biến để lưu tạm lại pass cũ
            string passOld = account.PassWord;
            //thay đổi pass cũ thành mảng trốn để in cho đẹp
            account.PassWord = "";
            printBang(account);
            Console.SetCursorPosition(13, 3);
            //nếu thỏa điều kiện thì nhận về chuỗi mới không thì chuỗi cũ
            pass = generalMethod.inputString(10,passOld);
            if(pass != passOld)
                return pass;
            else{
                noti("password phải dưới 10 ký tự");
                return passOld;
            }
        }
        public string inputTenNhanVien(NhanVien account)
        {   
            string tennv;
            string tennvOld = account.TenNhanVien;
            account.TenNhanVien = "";
            printBang(account);
            Console.SetCursorPosition(18,4);
            tennv = generalMethod.inputString(20,tennvOld);
            if(tennv != tennvOld)
                return tennv;
            else{
                noti("Tên nhân viên phải dưới 20 ký tự");
                return tennvOld;
            }
        }
        public string inputBirthDay(NhanVien accuont)
        {
                Console.Clear();
                Console.WriteLine(
                " ----------------------------- \n" +
                "|Ngày:                        |\n" +
                "|Tháng:                       |\n" +
                "|Năm:                         |\n" +
                " ----------------------------- "
            );
            //tạo datetime để kiểm tra
            DateTime res;
            try
            {
                Console.SetCursorPosition(6, 1);
                int day = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(7, 2);
                int month = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(5, 3);
                int year = int.Parse(Console.ReadLine());
                //để kiểm tra xem dữ liệu có hợp lệ so với lịch không
                res=new DateTime(year,month,day);
            }
            catch (Exception)
            {   
                noti("Nhập sai định dạng");
                return accuont.BirthDay;
            }
            //trả về chuỗi theo định dạng dd/mm/yyyy
            return res.ToString("dd/MM/yyyy");
        }
        public int inputGioiTinh()
        {
            int gt = -1;
            Console.Clear();
            Console.WriteLine(
                " ---------------------------- \n" +
                "|          1.Nam             |\n" +
                "|          2.Nữ              |\n" +
                "|         3.Xác nhận         |\n" +
                " ---------------------------- "
            );

            // tạo biến flag để dừng while
            bool flag = true;
            Console.SetCursorPosition(1, 1);
            //bắt đầu nhập
            while (flag)
            {
                switch (Console.ReadKey(true).Key)
                {
                    //chọn 1 gán gt là nam
                    case ConsoleKey.D1:
                        gt = 1;
                        Console.SetCursorPosition(11, 1);
                        break;
                    //chọn 1 gán gt là nữ
                    case ConsoleKey.D2:
                        gt = 0;
                        Console.SetCursorPosition(11, 2);
                        break;
                    //nhấn 3 để xác nhận

                    case ConsoleKey.D3:
                        if (gt != -1)
                            flag = false;
                        break;
                }
            }
            return gt;
        }

        public string inputCanCuoc(NhanVien account)
        {
            string cccdOld = account.CCCD;
            account.CCCD = "";
            printBang(account);
            Console.SetCursorPosition(9, 7);
            string cccd = Console.ReadLine();
            if(cccd.Length == 12 && isNumString(cccd))
            return cccd;
            else 
            {
                noti("CCCD là dãy số có 12 chữ số");
                return cccdOld;
            }
        }
        public string inputSDT(NhanVien account)
        {
            string sdtOld = account.SDT;
            account.SDT = "";
            printBang(account);
            Console.SetCursorPosition(8, 8);
            string sdt = Console.ReadLine();
            if((sdt.Length == 10 || sdt.Length == 9) && isNumString(sdt))
            return sdt;
            else 
            {
                noti("SDT là dãy số có 10 hoặc 9 chữ số");
                return sdtOld;
            }
        }
    }
}