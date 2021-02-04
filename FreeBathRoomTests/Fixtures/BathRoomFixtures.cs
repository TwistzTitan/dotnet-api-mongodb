using System;
using API.FreeBathroom.Data.Collections;
using API.FreeBathroom.Model;
using Bogus;
using MongoDB.Driver.GeoJsonObjectModel;

namespace FreeBathRoomTests.Fixtures
{
    public class BathRoomFixtures
    {
        
        public FreeBathRoom GeraFreeBathRoomParaAvaliacaoPositiva()
        {
            // Gerando localizacao Fake
            var listLocals = new Faker<GeoJson2DGeographicCoordinates>()
            
            .CustomInstantiator(gC => new GeoJson2DGeographicCoordinates(gC.Random.Double(-50.0,50.0),gC.Random.Double(-50.0,50.0)))
            
            .RuleFor(gC => gC.Latitude, gLa => gLa.Random.Double())
            
            .RuleFor(gC => gC.Longitude, gLt => gLt.Random.Double())
            
            .Generate();
            
            
            var fakeBath = new Faker<FreeBathRoom>("pt_BR").StrictMode(true)
            .CustomInstantiator(f => new FreeBathRoom(f.Random.Number(0,10),f.Lorem.Text(),f.Random.Double(-20,20),f.Random.Double(-40,30)))
            
            .RuleFor(fbr=> fbr.avaliacao, av => av.Random.Number(0,10))

            .RuleFor(fbr=> fbr.avaliacaoPositiva, avP => avP.Random.Int())

            .RuleFor(fbr=> fbr.avaliacaoNegativa, avN => avN.Random.Int())

            .RuleFor(fbr=> fbr.dicas, dic => dic.Lorem.Text())

            .RuleFor(fbr=> fbr.local, loc => loc.PickRandom<GeoJson2DGeographicCoordinates>(listLocals))

            .FinishWith((fk,fbr)=> Console.WriteLine("Generate fake bath {0}", fbr.avaliacao));           
            
            return fakeBath.Generate();
        }

    }
}