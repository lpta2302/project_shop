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