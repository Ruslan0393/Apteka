using System.Collections.Generic;
using System;
namespace C____Apteka
{
    public class Apteka{
        List<Dori> listDori = new List<Dori>();
        List<Xaridor> listUser = new List<Xaridor>();
        List<Data> listData = new List<Data>();
        

        public void Qoshish(string nomi, int soni, decimal narxi){
            this.listDori.Add((new Dori(nomi, soni, narxi)));
        }

        public void UserQoshish(string login, string porol, decimal summa, string ism, int qoldiq){
            this.listUser.Add((new Xaridor(login, porol, summa, ism, qoldiq)));
        }


        public bool Login(string login, string porol){
            for(int i=0; i<listUser.Count; i++){
                if(listUser[i].login == login && listUser[i].porol == porol){
                    return true;
                }
            }  
            return false;
        }


        public void SortQilish(){
            listDori.Sort((x, y) => x.nomi.CompareTo(y.nomi));
        }


        public List<Dori> Dorilar(){
            return this.listDori;
        }


        public List<Data> Malumotlar(){
            return this.listData;
        }

        public List<Xaridor> Mijoz(){
            return this.listUser;
        }


        public bool Izlash(string name){
            return listDori.Exists(v => v.nomi.ToLower() == name.ToLower());
        }
        

        public List<Dori> Search(string name) {
            List<Dori> searchList = new List<Dori>();
            for(int i=0; i<listDori.Count; i++){
                if(listDori[i].nomi.ToLower()==name.ToLower()){
                    searchList.Add(listDori[i]);
                }
            }
            return searchList;
        }

        public void Delet(string name){
            int index = listDori.FindIndex(v => v.nomi.ToLower() == name.ToLower());
            listDori.RemoveAt(index);
        }

        public int IndexIzlash(string name){
            return listDori.FindIndex(v => v.nomi.ToLower() == name.ToLower());
        }

        public bool SotibOlish(int index, int miqdor, string login){
            int userIndex = listUser.FindIndex(v => v.login == login);
            if((listDori[index].soni >= miqdor) && ((listDori[index].narxi)*miqdor <= listUser[userIndex].summa)){
                listDori[index].soni-=miqdor;
                listUser[userIndex].summa-=(listDori[index].narxi*miqdor);
                listUser[userIndex].qoldiq+=(listDori[index].narxi)*miqdor;
                this.listData.Add( new Data(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), listUser[userIndex].login, listDori[index].nomi, miqdor));
                return true;
            }

            return false;
        }



        public void AddMoney(decimal money, int index){
            listUser[index].summa+=money;
        }


    }

}
