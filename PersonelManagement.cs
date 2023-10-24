using General;
namespace PersonelManage
{
    public class ManagePersonel
    {
        GeneralMethod generalMethod = new GeneralMethod();
        private List<NhanVien> listNhanVien;
        public ManagePersonel(List<NhanVien> list){
            listNhanVien = list;
        }
        public void PrintQuanLyNhanVien()
        {
            Console.Clear();
            Console.SetCursorPosition(18, 0);
            Console.WriteLine("QUẢN LÝ NHÂN VIÊN ");
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Thêm nhân viên                                   |\n" +
                          "| 2. Hiển thị thông tin nhân viên                     |\n" +
                          "| 3. Tìm kiếm nhân viên                               |\n" +
                          "| 4. Xóa nhân viên                                    |\n" +
                          " ----------------------------------------------------- \n");
        }
        private int GenerateID()
        {
            int max = 0;
            foreach (NhanVien sv in listNhanVien)
            {
                if (max < sv.IdNhanVien)
                {
                    max = sv.IdNhanVien;
                }
            }
            return max+1;
        }
        private string CreateUserName( string tenNhanVien)
        {
            string userName, name;
            int spaceIndex = tenNhanVien.LastIndexOf(' ');
            name = generalMethod.convertToUnSign(tenNhanVien.Substring(spaceIndex + 1)); // Lấy phần sau khoảng trắng là tên
            Random random = new Random();
            userName = name.ToLower() + random.Next(100,999);
            return userName;
        }
        private string CreatePassword()
        {
            string passwordstr;
            int passwordint;
            Random random = new Random();
            passwordint = random.Next(1000, 9999);
            passwordstr = passwordint.ToString();
            return passwordstr;
        }
        private void PrintNhapNhanVien(string tenNV,int typeUser){
            Console.Clear();
            Console.WriteLine("0.Quay lại\n"+
                                " ------------------------------------------------------- \n" +
                                "| 1. Nhập tên nhân viên:{0,-32}|\n" +
                                "| 2. Admin/Member (nhập 1/0):{1,-29}|\n" +
                                "| 3. Xác nhận                                           |\n" +
                                " ------------------------------------------------------- ",
                                tenNV,(typeUser==-1)?"":typeUser);
        }
        public void NhapNhanVien()
        {
            bool flag = true;
            string tennv = "";
            int typeUser = -1;
            while (flag)
            {
                PrintNhapNhanVien(tennv,typeUser);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        PrintNhapNhanVien("",typeUser);
                        Console.SetCursorPosition(24,2);
                        tennv = generalMethod.inputString(20,tennv);
                        break;
                    case ConsoleKey.D2:
                        PrintNhapNhanVien(tennv,-1);
                        Console.SetCursorPosition(27,3);
                        typeUser = generalMethod.inputInt(0,1);
                        break;
                    case ConsoleKey.D3:
                        if(tennv != "" && typeUser != -1){
                            NhanVien nhanVien = new NhanVien();
                            nhanVien.IdNhanVien = GenerateID();
                            nhanVien.UserName = CreateUserName(tennv);
                            nhanVien.PassWord = CreatePassword();
                            nhanVien.TypeUser = typeUser;
                            nhanVien.TenNhanVien = tennv;
                            Console.Clear();
                            Console.WriteLine("Nhập thông tin nhân viên thành công !!!");
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey(true);
                            listNhanVien.Add(nhanVien);
                            setDataNhanVien();
                            flag = false;
                        }
                        break;
                    case ConsoleKey.D0:
                        return;
                }
            }
        }
        public void PrintTimNhanVien()
        {
            Console.Clear();
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Tìm kiếm theo tên                                |\n" +
                          "| 2. Tìm kiếm theo năm sinh                           |\n" +
                          " ----------------------------------------------------- \n");
        }
        public List<NhanVien> TimTen(string keyword)
        {
            List<NhanVien> KqTimKiem = new List<NhanVien>();
            //tìm kiếm nhấn viên có tên trùng với keyword đang tìm
            foreach (NhanVien nv in listNhanVien)
            {
               if (nv.TenNhanVien.ToUpper() == keyword.ToUpper())
               {
                  KqTimKiem.Add(nv);
               }
            }
            if(KqTimKiem.Count != 0)  
            return KqTimKiem;
            else
            return null;
        }
        public void SapXep()
        {
            Console.Clear();
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Sắp xếp theo tên nhân viên                       |\n" +
                          "| 2. Sắp xếp theo Id nhân viên                        |\n" +
                          "| 3. Sắp xếp theo giới tính                           |\n" +
                          "| 4. Lọc theo TypeUser                                |\n" +
                          "| 5. Lọc theo nam/nữ                                  |\n" +
                          "| 6. Thống kê nam nữ, typeuser                        |\n" +
                          " ----------------------------------------------------- \n");
        }
        public void ShowNhanVien(List<NhanVien> ListNhanVien)
        {
            string[] gioitinh = { "Nữ", "Nam" };
            string[] typeuser = { "member","admin" };
            Console.WriteLine("BẢNG THÔNG TIN NHÂN VIÊN");
            // Hiển thị tiêu đề cột 
            Console.WriteLine(" --------------------------------------------------------------------------------------------------------------- \n" +
                              "| Id |        Tên NV        | Sex |  BirthDay  |     CCCD     |     SDT     |  Type   |  Username  |  Password  |\n" +
                              " --------------------------------------------------------------------------------------------------------------- ");
            // hien thi danh sach sinh vien       
            foreach (NhanVien nhanvien in ListNhanVien)
            {
                Console.WriteLine("| {0, -3}| {1, -21}| {2, -4}| {3, -11}| {4,-13}| {5, -12}| {6,-8}| {7,-11}| {8,-11}|",
                nhanvien.IdNhanVien, nhanvien.TenNhanVien, gioitinh[nhanvien.GioiTinh],
                nhanvien.BirthDay, nhanvien.CCCD,nhanvien.SDT,
                typeuser[nhanvien.TypeUser],nhanvien.UserName,nhanvien.PassWord);
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------- ");
        }
        public void ShowNhanVien2()
        {
            string[] gioitinh = { "Nữ", "Nam" };
            string[] typeuser = { "member","admin" };
            Console.WriteLine("BẢNG THÔNG TIN NHÂN VIÊN");
            // Hiển thị tiêu đề cột 
            Console.WriteLine(" -------------------------------------------------------------------------------------\n" +
                              "| Id |        Tên NV        | Sex |  BirthDay  |     CCCD     |     SDT     |   Type  |\n" +
                              " -------------------------------------------------------------------------------------");
            // hien thi danh sach sinh vien       
            foreach (NhanVien nhanvien in listNhanVien)
            {
                Console.WriteLine("| {0, -3}| {1, -21}| {2, -4}| {3, -11}| {4,-13}| {5, -12}| {6,-8}|",
                nhanvien.IdNhanVien, nhanvien.TenNhanVien, gioitinh[nhanvien.GioiTinh],
                nhanvien.BirthDay, nhanvien.CCCD,nhanvien.SDT,
                typeuser[nhanvien.TypeUser]);
            }
            Console.WriteLine(" -------------------------------------------------------------------------------------");
        }
        public void SapXepTen(List<NhanVien> listNhanVien)
        {
            listNhanVien.Sort((nv1, nv2) =>
            {
                //lấy ra khoảng cách cuối cùng
                int spaceIndex1 = nv1.TenNhanVien.LastIndexOf(' ');
                int spaceIndex2 = nv2.TenNhanVien.LastIndexOf(' ');
                return nv1.TenNhanVien.Substring(spaceIndex1 + 1).ToUpper().CompareTo(nv2.TenNhanVien.Substring(spaceIndex2 + 1).ToUpper());
            });
        }
        public void SapXepID(List<NhanVien> listNhanVien)
        {
            listNhanVien.Sort
              (
                (nv1,nv2)=>
              {
                  return nv1.IdNhanVien.CompareTo(nv2.IdNhanVien);
              });
        }
        public void SapXepGioiTinh(List<NhanVien> listNhanVien){
            listNhanVien.Sort
                (
                (nv1,nv2)=>
                {
                    return nv1.GioiTinh.CompareTo(nv2.GioiTinh);
                }
                );
        }
        public void LocTheoGioiTinh(List<NhanVien> ListNhanVien, int dk)
        {
            string[] gioitinh = { "Nữ", "Nam" };
            string[] typeuser = { "member","admin" };
            Console.WriteLine("BẢNG THÔNG TIN NHÂN VIÊN");
            // Hiển thị tiêu đề cột 
            Console.WriteLine(" --------------------------------------------------------------------------------------------------------------- \n" +
                              "| Id |        Tên NV        | Sex |  BirthDay  |     CCCD     |     SDT     |  Type   |  Username  |  Password  |\n" +
                              " --------------------------------------------------------------------------------------------------------------- ");
            // hien thi danh sach sinh vien       
            foreach (NhanVien nhanvien in ListNhanVien)
            {
                if(nhanvien.GioiTinh == dk)
                Console.WriteLine("| {0, -3}| {1, -21}| {2, -4}| {3, -11}| {4,-13}| {5, -12}| {6,-8}| {7,-11}| {8,-11}|",
                nhanvien.IdNhanVien, nhanvien.TenNhanVien, gioitinh[nhanvien.GioiTinh],
                nhanvien.BirthDay, nhanvien.CCCD,nhanvien.SDT,
                typeuser[nhanvien.TypeUser],nhanvien.UserName,nhanvien.PassWord);
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------- ");
        }
        public void LocTheoTypeUser(List<NhanVien> ListNhanVien, int dk)
        {
            string[] gioitinh = { "Nữ", "Nam" };
            string[] typeuser = { "member","admin" };
            Console.WriteLine("BẢNG THÔNG TIN NHÂN VIÊN");
            // Hiển thị tiêu đề cột 
            Console.WriteLine(" --------------------------------------------------------------------------------------------------------------- \n" +
                              "| Id |        Tên NV        | Sex |  BirthDay  |     CCCD     |     SDT     |  Type   |  Username  |  Password  |\n" +
                              " --------------------------------------------------------------------------------------------------------------- ");
            // hien thi danh sach sinh vien       
            foreach (NhanVien nhanvien in ListNhanVien)
            {
                if(nhanvien.TypeUser == dk)
                Console.WriteLine("| {0, -3}| {1, -21}| {2, -4}| {3, -11}| {4,-13}| {5, -12}| {6,-8}| {7,-11}| {8,-11}|",
                nhanvien.IdNhanVien, nhanvien.TenNhanVien, gioitinh[nhanvien.GioiTinh],
                nhanvien.BirthDay, nhanvien.CCCD,nhanvien.SDT,
                typeuser[nhanvien.TypeUser],nhanvien.UserName,nhanvien.PassWord);
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------- ");
        }
        
        public void HienThiNhanVien(int choice){
            List<NhanVien> ListNhanVien = listNhanVien.GetRange(0,listNhanVien.Count);
            while (true)
            {
                SapXep();
                if(choice == 1)
                ShowNhanVien(ListNhanVien);
                else
                ShowNhanVien2();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        SapXepTen(ListNhanVien);
                        break;
                    case ConsoleKey.D2:
                        SapXepID(ListNhanVien);
                        break;
                    case ConsoleKey.D3:
                        SapXepGioiTinh(ListNhanVien);
                        break;
                    case ConsoleKey.D5:
                        Console.Write("Nhập 1 để lọc nam, 0 để lọc nữ: ");
                        int gt = generalMethod.inputInt(0,1);
                        if(gt!=-1){
                        LocTheoGioiTinh(ListNhanVien,gt);
                        Console.WriteLine("Nhấn phím bất kỳ để quay lại");
                        Console.ReadKey(true);
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.Write("Nhập 1 để lọc admin, 0 để lọc member: ");
                        int type = generalMethod.inputInt(0,1);
                        if(type!=-1){
                        LocTheoTypeUser(ListNhanVien,type);
                        Console.WriteLine("Nhấn phím bất kỳ để quay lại");
                        Console.ReadKey(true);
                        }
                        break;
                    case ConsoleKey.D6:
                        thongKe();
                        Console.WriteLine("Nhấn phím bất kỳ để quay lại");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D0:
                        return;
                }
            } 
        }
        public void PrintXoaNhanVien(int id)
        {
            Console.Clear();
            Console.SetCursorPosition(18, 0);
            Console.WriteLine("XÓA NHÂN VIÊN");
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Nhập mã nhân viên:{0,-31}|\n" +
                          "| 2. Xác nhận !                                       |\n" +
                          " ----------------------------------------------------- ",(id==-1)?"":id);
        }
        public int inputId()
        {
            Console.SetCursorPosition(23,3);
            int id = generalMethod.inputInt(1,99);
            return id;
        }
        public NhanVien TimId(int IdNhanVien)
        {
            NhanVien result = listNhanVien.Find(x => x.IdNhanVien ==  IdNhanVien);
            return result;
        }
        public bool XoaNhanVien(int IdNhanVien)
        {
            bool Xoa = false;
            // tìm kiếm sinh viên theo ID
            NhanVien nhanvien = (TimId(IdNhanVien));
            if (nhanvien != null)
            {
                Xoa = listNhanVien.Remove(nhanvien);
                setDataNhanVien();
                Console.WriteLine("Xóa thành công\nNhấn phím bất kỳ để tiếp tục");
                Console.ReadKey();
            }
            else{
                Console.WriteLine("Không tìm thấy Id\nNhấn phím bất kỳ để tiếp tục");
                Console.ReadKey();
            } 
            return Xoa;
        }
        private string fileNhanVien = "nhanvien.txt";
        private (int nam, int nu) countSex(List<NhanVien> listNhanVien)
        {
            int soNam = 0;
            int soNu = 0;

            foreach (NhanVien nhanVien in listNhanVien)
            {
                if (nhanVien.GioiTinh == 1) 
                {
                    soNam++;
                }
                else if (nhanVien.GioiTinh == 0)
                {
                    soNu++;
                }
            }
            return (soNam, soNu);
        }
        public void thongKe()
        {
            Console.WriteLine($"Tổng số Nhân Viên: {listNhanVien.Count}");
            var kqDemSex = countSex(listNhanVien);
            Console.WriteLine($"Số nam: {kqDemSex.nam}");
            Console.WriteLine($"Số nữ: {kqDemSex.nu}");
            var kqDemUser = countUser(listNhanVien);
            Console.WriteLine($"Số admin: {kqDemUser.admin}");
            Console.WriteLine($"Số member: {kqDemUser.member}");
        }  
        private (int admin, int member) countUser(List<NhanVien> listNhanVien)
        {
            int member = 0;
            int admin = 0;

            foreach (NhanVien nhanVien in listNhanVien)
            {
                if (nhanVien.TypeUser == 1)
                {
                    admin++;
                }
                else if (nhanVien.TypeUser == 0)
                {
                    member++;
                }
            }

            return (admin, member);
        }
public List<NhanVien> SearchByBirthYear(List<NhanVien> listNhanVien, int keyword)
{
    List<NhanVien> KqTimKiem = new List<NhanVien>();
            //tìm kiếm nhấn viên có tên trùng với keyword đang tìm
            foreach (NhanVien nv in listNhanVien)
            {
               if (nv.BirthDay.Length == 10 && int.Parse(nv.BirthDay.Substring(6)) < keyword)
               {
                  KqTimKiem.Add(nv);
               }
            }
            if(KqTimKiem.Count != 0)  
            return KqTimKiem;
            else
            return null;
}
public void PrintTimNhanVienByBirthYear()
{
    Console.Clear();
    Console.WriteLine("0. Quay lại");
    Console.Write(" ----------------------------------------------------- \n" +
                  "| 1. Tìm nhân viên theo năm sinh                     |\n" +
                  " ----------------------------------------------------- \n");
}

public void TimNhanVienTheoNamSinh()
{
    Console.Clear();
    PrintTimNhanVienByBirthYear();
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
            Console.Write("Nhập năm sinh: ");
            int birthYear = int.Parse(Console.ReadLine());
            List<NhanVien> nhanVienSinhTruocNam = SearchByBirthYear(listNhanVien, birthYear);
            if(nhanVienSinhTruocNam != null)
            ShowNhanVien(nhanVienSinhTruocNam);
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
            Console.ReadKey();
            break;
        case ConsoleKey.D0:
            return;
    }
}


        public void getDataNhanVien(){
            //using này để lấy dữ liệu vào cái list. đưa vào try catch để kiểm tra lỗi file
            try
                {
                    using(StreamReader sr = new StreamReader(fileNhanVien)){
                        string tmp;
                        //Đến cuối file sẽ trả về con trỏ null nên là khác null
                        while((tmp = sr.ReadLine())!=null){
                            listNhanVien.Add(new NhanVien(
                            int.Parse(tmp),sr.ReadLine(),sr.ReadLine(),
                            int.Parse(sr.ReadLine()),sr.ReadLine(),sr.ReadLine(),
                            int.Parse(sr.ReadLine()),sr.ReadLine(),sr.ReadLine()));
                        }
                    }
                }
            //nếu không thấy file thì báo lỗi
                catch (FileNotFoundException)
                {
                    Console.SetCursorPosition(0,0);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(
                        " ---------------------------------------------- \n" +
                        "|                                              |\n" +
                        "|       Không tìm thấy dữ liệu nhân viên       |\n" +
                        "|          Nhấn phím bất kỳ để thoát           |\n" +
                        "|                                              |\n" +
                        " ---------------------------------------------- "
                    );
                    Console.ReadKey();
                    return;
                }
        }
        public void setDataNhanVien(){
            //using này để ghi dữ liệu vào file
            using(StreamWriter wr = new StreamWriter(fileNhanVien)){
                foreach (NhanVien item in listNhanVien)
                {
                    wr.WriteLine(item.IdNhanVien);
                    wr.WriteLine(item.UserName);
                    wr.WriteLine(item.PassWord);
                    wr.WriteLine(item.TypeUser);
                    wr.WriteLine(item.TenNhanVien);
                    wr.WriteLine(item.BirthDay);
                    wr.WriteLine(item.GioiTinh);
                    wr.WriteLine(item.CCCD);
                    wr.WriteLine(item.SDT);
                }
                wr.Flush();
            }
        }
    }
}