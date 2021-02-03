using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace API.FreeBathroom.Model
{
    public interface IBathRoomInformation
    {
        void Avaliar(AbstractBathRoom el,int arg);

    }

}