using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class AccountData
{
    
    public string username;
    public string password;
    public string name;
    public int diamond;
    public int coin;

    public List<AccountCarData> carDatas = new List<AccountCarData>();


   

   


}

