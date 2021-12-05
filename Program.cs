using System;

namespace C____Apteka
{

    class Program
    {
      
        static void Main(string[] args)
        {
            Apteka apteka = new Apteka();
            var a = apteka.Dorilar();
            var data = apteka.Malumotlar();
            var mijoz = apteka.Mijoz();


            void DoriRoyhat(){
                apteka.SortQilish();
                Console.WriteLine("|{0,20}|{1,5}|{2,8}|","Nomi","Soni","Narxi");
                System.Console.WriteLine("-------------------------------------");
                for(int i=0; i<a.Count; i++){
                    Console.WriteLine("|{0,20}|{1,5}|{2,7}$|",a[i].nomi,a[i].soni,a[i].narxi);
                }                
            }

            void HisobotRoyhat(string login){
                Console.WriteLine("|{0,20}|{1,20}|{2,15}|{3,5}|","Dori nomi","Vaqt","Login","Son");
                System.Console.WriteLine("-----------------------------------------------------------------");
                for(int i=0; i<data.Count; i++){
                    if(data[i].dIsm==login){
                        Console.WriteLine("|{0,20}|{1,20}|{2,15}|{3,5}|",data[i].dDori,data[i].date,data[i].dIsm,data[i].son);
                    }
                }                
            }
     
            void DoriQoshish(){
                while(true){
                    Console.Write("Dorining nomi:  ");
                    string name = Console.ReadLine();
                    decimal DoriNarx=0;
                    int doriSoni=0;
                    try{
                        Console.Write("Dorining narxi:  ");
                        DoriNarx = decimal.Parse(Console.ReadLine());
                            
                        Console.Write("Dorining soni:  ");
                        doriSoni = int.Parse(Console.ReadLine());
                
                        apteka.Qoshish(nomi: name, soni: doriSoni, narxi: DoriNarx);
                    }
                    catch{
                        System.Console.WriteLine("Faqat son kiriting");
                    }
                    
                    Console.WriteLine("\n1-Yana qo'shish\t\t\t0-Orqaga");
                    try{
                        int son = int.Parse(Console.ReadLine());
                        System.Console.WriteLine();
                        if(son==1) continue;
                        else if(son==0) {
                            Console.Clear();
                            break;
                        }
                        else Console.WriteLine("Bunday buyruq mavjud emas");
                    }
                    catch{
                        Console.WriteLine("Faqat son kiriting");
                    }
                }
                
            }
   
            void DoriIzlash(){
                apteka.SortQilish();
                while(true){
                    Console.Write("Dori nomini kiriting:  ");
                    string name = Console.ReadLine();
                    if(apteka.Izlash(name)){
                        var searchList = apteka.Search(name);
                        Console.WriteLine("|{0,20}|{1,5}|{2,8}|","Nomi","Soni","Narxi");
                        Console.WriteLine("-------------------------------------");

                        for(int i=0; i<searchList.Count; i++){
                            Console.WriteLine("|{0,20}|{1,5}|{2,7}$|",searchList[i].nomi,searchList[i].soni,searchList[i].narxi);
                        }
                    }
                    else {
                        Console.WriteLine("Bunday dori mavjud emas");
                    }
                    Console.WriteLine("\n1-Yana izlash\t\t\t0-Orqaga");
                    try{
                        int son = int.Parse(Console.ReadLine());
                        System.Console.WriteLine();
                        if(son==1) continue;
                        else if(son==0) {
                            Console.Clear();
                            break;
                        }
                        else System.Console.WriteLine("Bunday buyruq mavjud emas");
                    }
                    catch{
                        System.Console.WriteLine("Faqat son kiriting");
                    }
                }
            }
 
            void DoriOchirish(){
                while(true){
                    System.Console.Write("Dori nomini kiriting:  ");
                    string name = Console.ReadLine();
                    if(apteka.Izlash(name)){
                        apteka.Delet(name);
                        Console.WriteLine($"\"{name}\" nomli dori ro'yhatdan o'chirildi");
                    }
                    else Console.WriteLine("Bunday nomli dori mavjud emas");


                    Console.WriteLine("\n1-Yana izlash\t\t\t0-Orqaga");
                    try{
                        int son = int.Parse(Console.ReadLine());
                        System.Console.WriteLine();
                        if(son==1) continue;
                        else if(son==0) {
                            Console.Clear();
                            break;
                        }
                        else System.Console.WriteLine("Bunday buyruq mavjud emas");
                    }
                    catch{
                        System.Console.WriteLine("Faqat son kiriting");
                    }
                }
            }

            void UserQoshishMethod(){
                string login;
                while(true){
                    Console.Write("Ism:  ");
                    string name = Console.ReadLine();
                    while(true){
                        Console.Write("Login:  ");
                        login = Console.ReadLine();
                        if(mijoz.Exists(v => v.login == login)){
                            System.Console.WriteLine("Bunday login mavjud");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.Write("Porol:  ");
                    string porol = Console.ReadLine();
                    decimal price=0;
                    try{
                        Console.Write("Balans:  ");
                        price = decimal.Parse(Console.ReadLine());
                        apteka.UserQoshish(login: login, porol: porol, summa: price, ism: name, qoldiq: 0);
                    }
                    catch{
                        Console.WriteLine("Son kiriting");
                    }
                    Console.Clear();
                    break;
                }
                UserMenu(login);                
            }
            
            void SotibOlish(string login){
                Console.Write("Dori nomini kiriting:  ");
                string name = Console.ReadLine();
                
                int miqdor=0;
                try{
                    Console.Write("Miqdorini kiriting:  ");
                    miqdor = int.Parse(Console.ReadLine());
                    Console.WriteLine("Son kiriting");
                    if(apteka.Izlash(name)){
                        int index = apteka.IndexIzlash(name);
                        if(apteka.SotibOlish(index, miqdor, login)){
                            Console.Clear();
                            System.Console.WriteLine("Xaridingiz uchun rahmat!!!");
                            if(a[index].soni==0){
                                apteka.Delet(a[index].nomi);
                            }
                        }
                        else{
                            Console.Clear();
                            System.Console.WriteLine($"Balansingizni teshkiring yoki {miqdor} ta dori yo'q!!!");
                        }
                    }
                    else{
                        Console.Clear();
                        Console.WriteLine("Bunday dori mavjud emas");
                    }
                }
                catch{
                    System.Console.WriteLine("Faqat son kiriting");
                }
            }

            void BalansToldirish(string login){
                while(true){
                    int index = mijoz.FindIndex(v => v.login==login);
                    Console.WriteLine($"Foydalanuvchining ismi :                  {mijoz[index].ism}\nBalans :                                  {mijoz[index].summa}$\nHarajatlar :                              {mijoz[index].qoldiq}$\n1-Hisobni to'ldirish\t\t\t0-Orqaga");
                    try{
                        string son = Console.ReadLine();
                        Console.Clear();
                        if(son=="1") {
                            decimal price=0;
                            Console.Write("Kiritilmoqchi bo'lgan summa:  ");
                            price = decimal.Parse(Console.ReadLine());
                            apteka.AddMoney(price, index);
                        }
                        else if(son=="0"){
                            break;
                        }
                        else{
                            Console.WriteLine("Bunday buyruq mavjud emas\n\n");
                            continue;
                        }
                    }
                    catch{
                        Console.WriteLine("Faqat son kiriting!!!\n\n");
                    }
                }
            }

            void UserMenu(string login){
                while(true){
                    System.Console.WriteLine("1-Sotib olish\n2-Hisobot\n3-Balans\n0-Orqaga");
                    try{
                        int son = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if(son==1) {
                            while(true){
                                DoriRoyhat();
                                try{
                                    Console.WriteLine("1-Harid\t\t\t0-Orqaga");
                                    son = int.Parse(Console.ReadLine());
                                    if(son==1) {
                                        SotibOlish(login);
                                    }
                                    else if(son==0){
                                        Console.Clear();
                                        break;
                                    }
                                    else {
                                        Console.Clear();
                                        Console.WriteLine("Bunday buyruq mavjud emas");
                                    }
                                }
                                catch{
                                    Console.Clear();
                                    Console.WriteLine("Faqat son kiriting");
                                }
                            }
                        }
                        else if(son==2){
                            while(true){
                                HisobotRoyhat(login);
                                try{
                                    Console.WriteLine("0-Orqaga");
                                    son = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    if(son==0){
                                        break;
                                    }
                                    else {
                                        Console.WriteLine("Bunday buyruq mavjud emas");
                                    }
                                }
                                catch{
                                    Console.Clear();
                                    Console.WriteLine("Faqat son kiriting");
                                }
                            }
                        }
                        else if(son == 3){
                            BalansToldirish(login);
                        }
                        else if(son==0){
                            break;
                        }
                        else{
                            Console.Clear();
                            Console.WriteLine("Bunday buyruq mavjud emas\n\n");
                            continue;
                        }
                    }
                    catch{
                        Console.WriteLine("Faqat son kiriting!!!\n\n");
                    }
                }
            }

            void UserLogin(){
                string login;
                int temp=0;
                while(true){
                    Console.Write("Login:  ");
                    login = Console.ReadLine();
                    Console.Write("Porol:  ");
                    string porol = Console.ReadLine();
                    if(apteka.Login(login: login, porol: porol)){
                        break;
                    }
                    else{
                        Console.WriteLine("Account topilmadi!!!\n1-Qayta urinish\t\t\t0-Oraga");
                        int son=int.Parse(Console.ReadLine());
                        if(son==1) continue;
                        else if(son==0) {
                            temp=1;
                            break;
                        }
                        else System.Console.WriteLine("Bunday buyruq mavjud emas");
                    }
                }
                if(temp==0){
                    Console.Clear();
                    UserMenu(login);

                }
            }

            while(true){
            Console.WriteLine("\"ArzonApteka\" ilovasiga xush kelibsiz\n1-Dori qo'shish\n2-Dori xarid qilish\n0-Orqaga");
                string son;
                son = Console.ReadLine();
                
                Console.Clear();
                if(son=="1"){
                    while(true){
                        Console.WriteLine("1-Dorilarning ro'yxatini ko'rish\n2-Yangi dori qo'shish\n3-Ro'yxatdan dori o'chirib tashlash\n4-Dori izlash\n0-Orqaga");
                        son=Console.ReadLine();
                        Console.Clear();
                        if(son=="1"){
                            while(true){
                                DoriRoyhat();
                                System.Console.WriteLine("\n0-Orqaga");
                                try{
                                    son = Console.ReadLine();
                                    if(son=="0") {
                                        Console.Clear();
                                        break;
                                    }
                                    else System.Console.WriteLine("Bunday buyruq mavjud emas");
                                }
                                catch{
                                    System.Console.WriteLine("Faqat son kiriting");
                                }
                            }
                        }
                        else if(son=="2") DoriQoshish();
                        else if(son=="3") DoriOchirish();
                        else if(son=="4") DoriIzlash();
                        else if(son=="0") break;
                    }
                }
                else if(son=="2"){
                    while(true){
                        Console.WriteLine("1-Ro'yhatdan o'tish\n2-Kirish\n0-Orqaga");
                        son=Console.ReadLine();
                        Console.Clear();
                        if(son=="1"){
                            UserQoshishMethod();
                        }
                        else if(son=="2"){
                            UserLogin();
                        }
                        else if(son=="0") break;
                        else Console.WriteLine("Bunday buyruq mavjud emas");
                    }
                }
                else if(son=="0"){
                    break;
                }
                else{
                    Console.WriteLine("Bunday buyruq mavjud emas\n\n");
                    continue;
                }
            }

        }
    }

}
