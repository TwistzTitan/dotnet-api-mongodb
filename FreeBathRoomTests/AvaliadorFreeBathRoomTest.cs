using NUnit.Framework;
using Moq;
using API.FreeBathroom.Model;
using API.FreeBathroom.Services;
using API.FreeBathroom.Data.Collections;

namespace FreeBathRoomTests
{
    public class Tests
    {
        public Mock<IBathRoomInformation> mockBathRoomInformation;
        public Mock<AbstractBathRoom> mockFreeBath;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Avaliador_Conta_Avaliacao_Positiva()
        { 
         
           mockBathRoomInformation.Setup(mBRA => mBRA.Avaliar(mockFreeBath.Object,It.IsInRange<int>(4,5,Range.Inclusive)));
           Assert.Equals(mockFreeBath.Object.avaliacaoPositiva, 1);
        }
    }
}