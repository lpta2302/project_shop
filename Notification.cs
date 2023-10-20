using General;
namespace Notification;
public class QuanLyThongBao
{
    private List<ThongBao> listThongBao;

    public QuanLyThongBao()
    {
        listThongBao = new List<ThongBao>();
    }
    GeneralMethod generalMethod = new GeneralMethod();
    private int GenerateID()
    {
        int max = 0;
        foreach (ThongBao tb in listThongBao)
        {
            if (max < tb.IdThongBao)
            {
                max = tb.IdThongBao;
            }
        }
        return max+1;
    }

    public void DangThongBao(string tieuDe, string noiDung)
    {
        ThongBao thongBao = new ThongBao(GenerateID(), tieuDe, noiDung);
        listThongBao.Add(thongBao);
        setDataThongBao();
    }
    public int inputIdThongBao(){
        return generalMethod.inputInt(0,99);
    }
    public void XoaThongBao(int id)
    {
        ThongBao thongBao = listThongBao.Find(t => t.IdThongBao == id);
        if (thongBao != null)
        {
            listThongBao.Remove(thongBao);
            setDataThongBao();
            Console.WriteLine($"Đã xóa thông báo số: {id}");
            Console.WriteLine("Nhập phím bất kỳ để tiếp tục");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"Không tìm thấy thông báo số: {id}");
            Console.WriteLine("Nhập phím bất kỳ để thử lại");
            Console.ReadKey();
        }
    }
    public void XemThongBao()
    {
        Console.Clear();
        foreach (ThongBao thongBao in listThongBao)
        {
            Console.WriteLine(thongBao.ToString());
        }
        Console.WriteLine("Nhấn phím bất kỳ để quay lại");
    }
    public void printBangThongBao(){
        Console.Clear();
        Console.WriteLine(
            "0. Quay lại \n" +
            " ---------------------------------------------- \n" +
            "|             Đăng và xem thông báo            |\n" +
            "|1. Đăng thông báo                             |\n" +
            "|2. Xóa thông báo                              |\n" +
            "|3. Xem thông báo                              |\n" +
            " ---------------------------------------------- ");
    }
    private string fileThongBao = "thongbao.txt";
    public void getDataThongBao(){
        //try catch này để lấy dữ liệu vào cái list
        try
            {
                using(StreamReader sr = new StreamReader(fileThongBao)){
                    string tmp;
                    while((tmp = sr.ReadLine())!=null){
                        listThongBao.Add(new ThongBao(int.Parse(tmp),sr.ReadLine(),sr.ReadLine()));
                    }
                }
            }
            //nếu không thấy file thì báo lỗi
            catch (FileNotFoundException)
            {
                Console.SetCursorPosition(0,0);
                Console.Clear();
                Console.WriteLine(
                    " ---------------------------------------------- \n" +
                    "|                                              |\n" +
                    "|      Không tìm thấy dữ liệu thông báo        |\n" +
                    "|          Nhấn phím bất kỳ để thoát           |\n" +
                    "|                                              |\n" +
                    " ---------------------------------------------- "
                );
                Console.ReadKey();
                return;
            }
    }
    public void setDataThongBao(){
            //using này để ghi dữ liệu vào file
            using(StreamWriter wr = new StreamWriter(fileThongBao)){
                foreach (ThongBao item in listThongBao)
                {
                    wr.WriteLine(item.IdThongBao);
                    wr.WriteLine(item.TieuDe);
                    wr.WriteLine(item.NoiDung);
                }
                wr.Flush();
            }
    }
}
