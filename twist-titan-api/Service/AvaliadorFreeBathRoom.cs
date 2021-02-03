using API.FreeBathroom.Model;

namespace API.FreeBathroom.Services
{
    public class AvaliadorFreeBathRoom : IBathRoomInformation
    {
        public AvaliadorFreeBathRoom(){}
        public void Avaliar(AbstractBathRoom fbf, int av){
                     
                     if(av <= 3) 
                            fbf.avaliacaoNegativa++;
                     else
                     {
                            fbf.avaliacaoPositiva++;
                     }
                     
                     fbf.avaliacao=(fbf.avaliacao/(fbf.avaliacaoPositiva + fbf.avaliacaoNegativa));               
              }
              
    }
}