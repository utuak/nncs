public class NeuralNetwork
{
    private Random rand = new Random();
    private readonly int inputNodes, hiddenNodes, outputNodes;
    private float learningRate;
    private UtuakMatrix wih, who;

    public void Train(float[] inputsList, float[] targetsList)
    {
        UtuakMatrix inputs = new UtuakMatrix(inputsList).Transpose();
        UtuakMatrix targets = new UtuakMatrix(targetsList).Transpose();

        UtuakMatrix hiddenInputs = UtuakMatrix.Dot(wih, inputs);
        UtuakMatrix hiddenOutputs = Sigmoid(hiddenInputs);

        UtuakMatrix finalInputs = UtuakMatrix.Dot(who, hiddenOutputs);
        UtuakMatrix finalOutputs = Sigmoid(finalInputs);

        UtuakMatrix outputErrors = targets - finalOutputs;
        UtuakMatrix hiddenErrors = UtuakMatrix.Dot(who.Transpose(), outputErrors);

        who += UtuakMatrix.Dot(outputErrors * (finalOutputs * (1f - finalOutputs)), hiddenOutputs.Transpose()) * learningRate;
        wih += UtuakMatrix.Dot(hiddenErrors * (hiddenOutputs * (1f - hiddenOutputs)), inputs.Transpose()) * learningRate;
    }

    public float[] Query(float[] inputsList)
    {
        UtuakMatrix inputs = new UtuakMatrix(inputsList).Transpose();

        UtuakMatrix hiddenInputs = UtuakMatrix.Dot(wih, inputs);
        UtuakMatrix hiddenOutputs = Sigmoid(hiddenInputs);

        UtuakMatrix finalInputs = UtuakMatrix.Dot(who, hiddenOutputs);
        UtuakMatrix finalOutputs = Sigmoid(finalInputs);

        return finalOutputs.AsList();
    }

    private void SetWeights()
    {
        wih = new UtuakMatrix(hiddenNodes, inputNodes);
        who = new UtuakMatrix(outputNodes, hiddenNodes);
        for (int x = 0; x < hiddenNodes; x++)
        {
            for (int y = 0; y < inputNodes; y++)
            {
                wih.matrix[x, y] = (float)rand.NextDouble() - 0.5f;
            }
        }
        for (int x = 0; x < outputNodes; x++)
        {
            for (int y = 0; y < hiddenNodes; y++)
            {
                who.matrix[x, y] = (float)rand.NextDouble() - 0.5f;
            }
        }
    }

    private UtuakMatrix Sigmoid(UtuakMatrix x)
    {
        UtuakMatrix newm = new UtuakMatrix(x.x, x.y);
        for (int i = 0; i < x.x; i++)
        {
            for (int j = 0; j < x.y; j++)
            {
                newm.matrix[i, j] = 1f / (1f + (float)Math.Exp(-x.matrix[i, j]));
            }
        }
        return newm;
    }

    public NeuralNetwork(int inodes, int hnodes, int onodes, float lr)
    {
        inputNodes = inodes;
        hiddenNodes = hnodes;
        outputNodes = onodes;
        learningRate = lr;
        SetWeights();
    }
}
