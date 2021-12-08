using NUnit.Framework;

namespace Tests
{
    public class MatrixTests
    {
        [Test]
        public void MapFilter()
        {
            Matrix boardSpace = Matrix.ZeroMatrix(10,10);

            boardSpace[1,1] = 1;

            Matrix aoeMatrix = Matrix.ZeroMatrix(10, 10);

            aoeMatrix[1-1,1] = 1;
            aoeMatrix[1+0,1] = 1;
            aoeMatrix[1+1,1] = 1;
            
            aoeMatrix[1,1-1] = 1;
            aoeMatrix[1,1+0] = 1;
            aoeMatrix[1,1+1] = 1;

            var resultMatrix = Matrix.BitAnd(boardSpace, aoeMatrix);

            Assert.True(Matrix.Equals(boardSpace, resultMatrix));
        }
    }
}