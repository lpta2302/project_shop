using General;

namespace InventoryManage;

class ManageInventory
{
    GeneralMethod generalMethod = new GeneralMethod();
    private List<HangHoa> listHangHoa = new List<HangHoa>();
    public ManageInventory(List<HangHoa> list)
    {
        listHangHoa = list;
    }
    public void printInventory()
        // in 
    {
        Console.Clear();
        Console.WriteLine("0 Quay lại");
        Console.WriteLine(" ------------------------------------------------------------- ");
        Console.WriteLine("|1.Hiển thị danh sách hàng tồn kho                            |");
        Console.WriteLine("|2.Cập nhật kho                                               |");
        Console.WriteLine(" ------------------------------------------------------------- ");

    }
    public void showInventoryListAdmin()
    {
        Console.Clear();
        Console.WriteLine("0.Quay lại");
        Console.WriteLine("               Hiển thị danh sách hàng tồn kho                  ");
        Console.WriteLine("1.Sắp xếp theo Mã hàng                                          ");
        Console.WriteLine("2.Sắp xếp theo Tên hàng                                         ");
        Console.WriteLine(" ------------------------------------------ ");
        Console.WriteLine("{0, 6} {1, -22} {2, 8}", "|  ID  |", "      Tên Hàng       |", " Số lượng  |");
        Console.WriteLine(" ------------------------------------------ ");
        /* Dùng foreach dùng để lọc qua từng thành phần trong list hàng hóa
         * sử dụng biến item để truy cập các thuộc tính IdHang, TenHang, SoLuong của đối tượng HangHoa*/
        foreach (HangHoa item in listHangHoa)
        {
            Console.WriteLine("|{0, 5} |{1, -22}| {2, 8}   |", item.IdHang, item.TenHang, item.SoLuong);
        }
        Console.WriteLine(" ------------------------------------------ ");
    }
    public void HienThiBang()
    {
        bool flag = true;
        while (flag)
        {
            showInventoryListAdmin();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D0:
                    SapXepTheoMaHang();
                    return;
                case ConsoleKey.D1:
                    SapXepTheoMaHang();
                    break;
                case ConsoleKey.D2:
                    SapXepTheoTen();
                    break;
            }
        }
    }
    public void SapXepTheoTen()
    {
        listHangHoa.Sort((nv1, nv2) =>
        {
            //to upper để viết in lên
            //compare to để so sánh
            return nv1.TenHang.ToUpper().CompareTo(nv2.TenHang.ToUpper());
        });
    }
    public void SapXepTheoMaHang()
    {
        listHangHoa.Sort(delegate (HangHoa hh1, HangHoa hh2)
        {
            return hh1.IdHang.CompareTo(hh2.IdHang);
        }
        );
    }
    public void CapNhatKho()
    {
        while (true)
        {
            updateInventoryAdmin();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D0:
                    return;
                case ConsoleKey.D1:
                    addItem();
                    break;
                case ConsoleKey.D2:
                    deleteItem();
                    break;
                case ConsoleKey.D3:
                    updateItem();
                    break;
            }
        }
    }
    public void updateInventoryAdmin()
    {
        Console.Clear();
        Console.WriteLine("0.Quay lại                                                  Admin");
        Console.WriteLine("                     Cập nhật kho                          ");
        Console.WriteLine("1.Thêm hàng hóa          ");
        Console.WriteLine("2.Xóa hàng hóa           ");
        Console.WriteLine("3.Cập nhật hàng hóa           ");
    }
    private void addItem()
    {
        string tenHang = "";
        int soLuong = -1;
        bool flag = true;
        while (flag)
        {
            newInventory(tenHang, soLuong);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D0:
                    return;
                case ConsoleKey.D1:
                    newInventory("", soLuong);
                    Console.SetCursorPosition(20, 2);
                    tenHang = generalMethod.inputString(20, tenHang);
                    break;
                case ConsoleKey.D2:
                    newInventory(tenHang, -1);
                    Console.SetCursorPosition(16, 3);
                    soLuong = generalMethod.inputInt(0, 999999);
                    break;
                case ConsoleKey.D3:
                    if (tenHang != "" && soLuong != -1)
                        listHangHoa.Add(new HangHoa(GenerateID(), tenHang, soLuong));
                    setDataHangHoa();
                    break;
            }
        }
    }
    private int GenerateID()
    {
        //tạo id ban đầu 
        int max = 0;
        //tìm số id lớn nhất
        foreach (HangHoa hang in listHangHoa)
        {
            if (max < hang.IdHang)
            {
                max = hang.IdHang;
            }
        }
        //trả về số id mới
        return max + 1;
    }
    public void newInventory(string tenHang, int soLuong)
    {
        Console.Clear();
        Console.WriteLine("0.Quay lại                                                   Admin");
        Console.WriteLine("                     Thêm hàng hóa                           ");
        Console.WriteLine($"1.Nhập tên hàng hóa:{tenHang}");
        Console.WriteLine("2.Nhập số lượng:{0}", (soLuong == -1) ? "" : soLuong);
        Console.WriteLine("3.Xác nhận");

    }
    private void deleteItem()
    {
        bool flag = true;
        int maHangHoa = -1;
        while (flag)
        {
            deleteInventory(maHangHoa);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D0:
                    return;
                case ConsoleKey.D1:
                    deleteInventory(-1);
                    Console.SetCursorPosition(14, 2);
                    maHangHoa = generalMethod.inputInt(1, 999);
                    break;
                case ConsoleKey.D2:
                    if (maHangHoa != -1)
                    {
                        XoaHangHoa(maHangHoa);
                        setDataHangHoa();
                        maHangHoa = -1;
                    }
                    break;
            }
        }
    }
    private void deleteInventory(int maHangHoa)
    {
        Console.Clear();
        Console.WriteLine("0.Quay lại                                                   Admin");
        Console.WriteLine("                    Xóa hàng hóa                             ");
        Console.WriteLine("1.Mã hàng hóa:{0}", (maHangHoa == -1) ? "" : maHangHoa);
        Console.WriteLine("2.Xác nhận");
    }
    public HangHoa TimId(int IdHang)
    {
        HangHoa result = listHangHoa.Find(x => x.IdHang == IdHang);
        return result;
    }
    public bool XoaHangHoa(int IdHangHoa)
    {
        bool Xoa = false;
        // tìm kiếm sinh viên theo ID
        HangHoa hanghoa = (TimId(IdHangHoa));
        if (hanghoa != null)
        {
            Xoa = listHangHoa.Remove(hanghoa);
            Console.WriteLine("Xóa thành công\nNhấn phím bất kỳ để tiếp tục");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Không tìm thấy Id\nNhấn phím bất kỳ để tiếp tục");
            Console.ReadKey();
        }
        return Xoa;
    }
    public void updateItem()
    {
        while(true){
            showInventoryListAdmin();
            Console.WriteLine("Nhấn 1 để cập nhật hàng");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Nhập mã hàng hóa: ");
                    int maHangHoa = generalMethod.inputInt(1, 999);
                    if(maHangHoa == -1)continue;
                    HangHoa hangHoa = TimId(maHangHoa);
                    if (hangHoa == null)
                    {
                        Console.WriteLine("Không tìm thấy hàng hóa");
                        Console.WriteLine("Nhấn phím bất kỳ để thử lại");
                        Console.ReadKey(true);
                    }
                    else{
                        editItem(hangHoa);
                        return;
                    }
                    break;
                case ConsoleKey.D0:
                return;
            }
        }
    }
    private void printEditItem(HangHoa hangHoa, int inc, int dec)
    {
        Console.Clear();
        Console.WriteLine("0.Quay lại                                                   Admin");
        Console.WriteLine("                     Cập nhật hàng hóa                           ");
        Console.WriteLine("Tên hàng:{0}", hangHoa.TenHang);
        Console.WriteLine("Số lượng còn lại:{0,8}", hangHoa.SoLuong);
        Console.WriteLine("1.Nhập số lượng tăng:{0}", (inc == -1) ? "" : inc);
        Console.WriteLine("2.Nhập số lượng giảm:{0}", (dec == -1) ? "" : dec);
        Console.WriteLine("3.Xác nhận");
    }
    public void editItem(HangHoa hangHoa)
    {   
        //tạo 2 biến tăng và giảm
        int inc = -1, dec = -1;
        while (true)
        {
            printEditItem(hangHoa, inc, dec);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    //nhập biến tăng
                    Console.SetCursorPosition(21, 4);
                    inc = generalMethod.inputInt(0, 999999 - hangHoa.SoLuong);
                    break;
                case ConsoleKey.D2:
                    //nhập biến giảm
                    Console.SetCursorPosition(21, 5);
                    dec = generalMethod.inputInt(0, hangHoa.SoLuong + Math.Max(inc, 0));
                    break;
                case ConsoleKey.D3:
                    if (inc != -1 || dec != -1)
                    {
                        //xác nhận nếu biến nhập vào là khả thi trong trường hợp:
                        //  biến tăng và nhập có dữ liệu
                        //  số lượng của hàng hóa không âm và nhỏ hơn 999999
                        hangHoa.SoLuong += (Math.Max(inc, 0) - Math.Max(dec, 0));
                        setDataHangHoa();
                        inc = -1; dec = -1;
                    }
                    break;
                case ConsoleKey.D0:
                    return;
            }
        }
    }
    private string fileHangHoa = "hanghoa.txt";
    public void getDataHangHoa()
    {
        //try catch này để đọc dữ liệu vào list hàng hóa
        try
        {
            using (StreamReader sr = new StreamReader(fileHangHoa))
            {
                string tmp;
                while ((tmp = sr.ReadLine()) != null)
                {
                    listHangHoa.Add(new HangHoa(
                        int.Parse(tmp), sr.ReadLine(),
                        int.Parse(sr.ReadLine())));
                }
            }
        }
        //nếu không thấy file thì báo lỗi
        catch (FileNotFoundException)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                " ---------------------------------------------- \n" +
                "|                                              |\n" +
                "|       Không tìm thấy dữ liệu hàng hóa        |\n" +
                "|          Nhấn phím bất kỳ để thoát           |\n" +
                "|                                              |\n" +
                " ---------------------------------------------- "
            );
            Console.ReadKey();
            return;
        }
    }
    public void setDataHangHoa()
    {
        //try catch này để ghi dữ liệu vào file
        using (StreamWriter wr = new StreamWriter(fileHangHoa))
        {
            foreach (HangHoa item in listHangHoa)
            {
                wr.WriteLine(item.IdHang);
                wr.WriteLine(item.TenHang);
                wr.WriteLine(item.SoLuong);
            }
            wr.Flush();
        }
    }
}