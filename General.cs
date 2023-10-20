namespace General;
//Tạo class user
public class GeneralMethod{
    //hàm này để nhập chuỗi đúng định dạng
    public string inputString(int max,string oldValue)
    {
        string res;
        res = Console.ReadLine();
        //nếu chuỗi lớn hơn max trả về giá trị cũ không thì trả về chuỗi mới
        if (res.Length > max)
            return oldValue;
        else return res;
    }
    //hàm này để nhập số đúng với yêu cầu
    public int inputInt(int min, int max)
    {
        int res;
        //nếu chuỗi là số và trong khoảng cho phép thì trả về số mới không thì trả về -1
        if (int.TryParse(Console.ReadLine(), out res) && min <= res && res <= max)
        {
            return res;
        }
        return -1;
    }
    // hàm này để chuyển đổi về chữ không dấu
    public string convertToUnSign(string s)
    {
        string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
        "đ",  
        "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
        "í","ì","ỉ","ĩ","ị",  
        "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
        "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
        "ý","ỳ","ỷ","ỹ","ỵ",};  
        string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
        "d",  
        "e","e","e","e","e","e","e","e","e","e","e",  
        "i","i","i","i","i",  
        "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
        "u","u","u","u","u","u","u","u","u","u","u",  
        "y","y","y","y","y",};  
        for (int i = 0; i < arr1.Length; i++)
        {  
            //thay thế từng chữ có dấu trong chuỗi thành chữ không dấu
            s = s.Replace(arr1[i], arr2[i]);  
            s = s.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());  
        }  
        return s;  
    }
}
public class NhanVien
{
    //tạo dữ liệu cho Nhân viên
    public int IdNhanVien;
    public string UserName;
    public string PassWord;
    public int TypeUser;
    public string TenNhanVien;
    public string BirthDay;
    public int GioiTinh;
    public string CCCD;
    public string SDT;
    //mặc định khi tạo mới một nhân viên
    public NhanVien(){
        IdNhanVien = -1;
        UserName = ""; 
        PassWord = ""; 
        TypeUser = 0; 
        TenNhanVien = ""; 
        BirthDay = ""; 
        GioiTinh = 0; 
        CCCD = ""; 
        SDT = ""; 
    }
    // để thêm dữ liệu vào nhân viên dễ hơn
    public NhanVien(int _IdNhanVien,string _UserName,string _PassWord,
    int _TypeUser,string _TenNhanVien,string _BirthDay,
    int _GioiTinh,string _CCCD,string _SDT){
        IdNhanVien = _IdNhanVien; 
        UserName = _UserName; 
        PassWord = _PassWord; 
        TypeUser = _TypeUser; 
        TenNhanVien = _TenNhanVien; 
        BirthDay = _BirthDay; 
        GioiTinh = _GioiTinh; 
        CCCD = _CCCD; 
        SDT = _SDT; 
    }
}
//Tạo class HangHoa
public class HangHoa{
    //tạo dữ liệu cho hàng hóa
    public int IdHang;
    public string TenHang;
    public int SoLuong;
    //mặc định khi thêm hh
    public HangHoa(){
        IdHang = -1;
        TenHang = "";
        SoLuong = 0;
    }
    //để thêm dl vào dễ hơn
    public HangHoa(int id,string ten,int soLuong){
        IdHang = id;
        TenHang = ten;
        SoLuong = soLuong;
    }
    

}
//Tạo class ThongBao
public class ThongBao{
    //Tạo các thuộc tính cho class thông báo
    public int IdThongBao;
    public string TieuDe;
    public string NoiDung;
    //để thêm dl vào dễ hơn
    public ThongBao(int id, string tieuDe, string noiDung)
    {
        IdThongBao = id;
        TieuDe = tieuDe;
        NoiDung = noiDung;
    }
    //in thông báo ra
    public override string ToString()
    {
        return $"Thông báo số: {IdThongBao}\nTiêu đề: {TieuDe}\nNội dung:\n{NoiDung}\n{"".PadRight(50,'-')}";
    }
}
public class Calender
{
    int[,] calender = new int[5,7];
    public Calender(){
        makeCalender();
    }
    private int dayToInt(DateTime time){
        //hàm này để trả về dạng số của dayofweek
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                return 0;
                case DayOfWeek.Tuesday:
                return 1;
                case DayOfWeek.Wednesday:
                return 2;
                case DayOfWeek.Thursday:
                return 3;
                case DayOfWeek.Friday:
                return 4;
                case DayOfWeek.Saturday:
                return 5;
                case DayOfWeek.Sunday:
                return 6;
            }
            return -1;
        }
        public void printCalender(){
            Console.SetCursorPosition(47,0);
            //in ra ngày hiện tại
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.SetCursorPosition(47,1);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //in lịch
            Console.WriteLine("T2  T3  T4  T5  T6  T7  CN  ");
            Console.ForegroundColor = ConsoleColor.Black;
            for(int i=0;i<calender.GetLength(0);i++){
                Console.SetCursorPosition(47,2+i);
                for(int j=0;j<calender.GetLength(1);j++){
                    Console.Write("{0,2}  ",(calender[i,j]==0)?"  ":calender[i,j]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
            private void makeCalender(){
                //hàm tạo lịch
                //lấy tháng hiện tại
                int thisMonth = DateTime.Now.Month;
                //lấy ngày đầu tiên trong tháng
                DateTime day = new DateTime(DateTime.Now.Year,thisMonth,1);
                int firstDay = dayToInt(day);
                //tạo dòng ngày đầu tiên
                for(int i=firstDay;i<calender.GetLength(1);i++){
                    //gán ngày vào mảng
                    calender[0,i] = day.Day;
                    //tăng ngày lên
                    day = day.AddDays(1);
                }
                //tạo những ngày còn lại
                for(int i=1;i<calender.GetLength(0);i++){
                    for(int j=0;j<calender.GetLength(1);j++){
                    calender[i,j] = day.Day;
                    day = day.AddDays(1);
                    //nếu hết tháng thì dừng
                    if(day.Month > thisMonth)return;
                    }
                }
            }
        
}