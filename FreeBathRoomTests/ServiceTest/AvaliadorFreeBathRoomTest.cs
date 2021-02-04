using NUnit.Framework;
using Moq;
using API.FreeBathroom.Model;
using API.FreeBathroom.Services;
using API.FreeBathroom.Data.Collections;
using FreeBathRoomTests.Fixtures;


namespace FreeBathRoomTests
{
    public class Tests
    {
        public Mock<IBathRoomInformation> mockBathRoomInformation = new Mock<IBathRoomInformation>();
        public Mock<AbstractBathRoom> mockFreeBath = new Mock<AbstractBathRoom>();

        public BathRoomFixtures bathFixture = new BathRoomFixtures(); 
           
        [SetUp]
         public void Setup(){

           mockBathRoomInformation.Setup(
               mBRA => mBRA.Avaliar(mockFreeBath.Object,It.IsInRange<int>(-5,10,Range.Inclusive)))
               .Callback<AbstractBathRoom,int>(
                   (e,n)=>{ 
                      Assert.IsNotNull(e,"Sem Bathroom definido!");
                      Assert.IsTrue((n>=0),"Nota fora do range aceito"); 
                      
                      if(n >= 6) e.avaliacaoPositiva++;
                      else { e.avaliacaoNegativa++;}

                      e.avaliacao = e.avaliacao/(e.avaliacaoNegativa+e.avaliacaoPositiva);

                   });

        }

        [TestCase(6)]
        public void Avaliador_Conta_Avaliacao_Positiva(int note)
        { 
           var mockFreeBathRoom  = mockFreeBath.Object;
           var freeBathRoomFixture = bathFixture.RetornaFreeBathRoomCorreto();
           
           var mockAvaliador = mockBathRoomInformation.Object;
           var avaliadorFreeBathRoom = new AvaliadorFreeBathRoom();

           // Avaliação Positiva Atual
           var avPMockFreeBath = mockFreeBathRoom.avaliacaoPositiva;
           var avPFreeBathFixture = freeBathRoomFixture.avaliacaoPositiva;
           
           // Execução da avaliação
           mockAvaliador.Avaliar(mockFreeBathRoom,note);
           avaliadorFreeBathRoom.Avaliar(freeBathRoomFixture,note);
           
           
           Assert.That(mockFreeBathRoom.avaliacaoPositiva, Is.GreaterThan(avPMockFreeBath));
           Assert.That(freeBathRoomFixture.avaliacaoPositiva, Is.GreaterThan(avPFreeBathFixture));
          
        }

        [TestCase(4)]
        [TestCase(2)]
        [TestCase(1)]
        public void Avaliador_Conta_Avaliacao_Negativa(int note)
        { 
           var mockFbr  = mockFreeBath.Object;
           var mockValidator = mockBathRoomInformation.Object;
           mockValidator.Avaliar(mockFbr,note);
           Assert.Greater(mockFbr.avaliacaoNegativa,0);
        }

        [TestCase(-1)]
        [TestCase(-3)]
        public void Avaliador_Retorna_Assertion_Numero_Fora_Range(int note)
        { 
           var mockFbr  = mockFreeBath.Object;
           var mockValidator = mockBathRoomInformation.Object;   
           Assert.Throws<AssertionException>(()=>mockValidator.Avaliar(mockFbr,note));
        }
        

    }
}