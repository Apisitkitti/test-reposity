using System;
class ListData
{
    private List<Reserve>listroom;
    private List<Room>listroominfo; 

    public ListData()
    {
        this.listroom= new List<Reserve>();
        this.listroominfo= new List<Room>();
    }
    public void RoomAdd(Reserve reserve)
    {
        this.listroom.Add(reserve);
    }
    public void RoomInfoAdd(Room room)
    {
        this.listroominfo.Add(room);
    }
    public void RoomDete(int choose)
    {
       listroom.RemoveAt(choose);
    }
    public void ReserveRoom()
   {
    int count = 0;
    if(listroom.Count == 0)
    {
        Console.WriteLine("Not have any reserve!!");
    }
    else if(listroom.Count > 0)
    {
        foreach(Reserve reserveroom in listroom)
        {
            count++;
            if(reserveroom is Room room)
            {
                Console.WriteLine("{0}. {1} {2} | Reserve: {3} | Amount: {4} \n   Activity: {5}",count,reserveroom.GetName(),reserveroom.GetSurname(),reserveroom.GetRoomname(),reserveroom.GetAmount(),reserveroom.GetActivity());
            }
        }
    } 
   }
   public bool RoomAmountcheck(string name,int amount )
   {
        foreach(Room room in listroominfo)
        {
            if(amount > room.GetAmount()&& name.Equals(room.GetRoomname()))
            {
                return false;
            }
            else if(amount <= room.GetAmount()&& name.Equals(room.GetRoomname()))
            {
                return true;
            }
        }
        return RoomAmountcheck(name,amount);  
    }
    //deletefunti
    public bool CheckDelete()
    {
        if(listroom.Count == 0 )
        {
            return false;
        }
        else if(listroom.Count >0)
        {
            return true;
        }
        else if(listroom.Count == null)
        {
            return false;
        }
        else
        {
            return false;
        }
    }
    //checkว่าคือใคร
   public void WHoisthat(string id , string password)
   {
    foreach(Person person in peoplelist)
    {
        if(person is Teacher teacher)
        {
            if(id.Equals(teacher.GetId())&&password.Equals(teacher.GetPassword()))
            {
                Console.WriteLine("{0} {1}",teacher.GetName(),teacher.GetSurname());
            }
        }
        else if (person is Student student)
        {
             if(id.Equals(student.GetID())&&password.Equals(student.GetPassword()))
            {
                Console.WriteLine("{0} {1}",student.GetName(),student.GetSurname());
            }
        }
    } 
   }
 //CheckROomAgain()
    public bool CheckRoomSUm(string roomname,string name, string surname)
    {
        foreach(Reserve reserve in listroom)
        {
             if(name.Equals(reserve.GetName())&&roomname.Equals(reserve.GetRoomname())&&surname.Equals(reserve.GetSurname()))
                {
                    return false;
                } 
        }
        return true;
 
    }
}