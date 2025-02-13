// See https://aka.ms/new-console-template for more information

namespace MathGame;

public class MathProblem
{
   private char _operation;
   private int _leftOperand;
   private int _rightOperand;

   public MathProblem(int leftOperand, char operation, int rightOperand)
   {
      this._leftOperand= leftOperand;
      this._operation = operation;
      this._rightOperand = rightOperand;
   }
   
//   public int LeftOperand { get; set; }
 //  public int RightOperand { get; set; }
 //  public string Operation { get; set; }

   public int Solution()
   {
      switch (this._operation)
      {
         case '+':
            return this._leftOperand + this._rightOperand; 
         case '-':
            return this._leftOperand - this._rightOperand;
         case '*':
            return this._leftOperand * this._rightOperand;
         case '/':
            if (this._rightOperand == 0)
            {
               throw new ArithmeticException("Cannot divide by 0"); 
            }
            else
            {
               return this._leftOperand / this._rightOperand;
            }
         default:
            throw new InvalidOperationException($"Operation {this._operation} is not supported.");
      }
   }

   public override string ToString()
   {
      return $"{this._leftOperand} {this._operation} {this._rightOperand} = ";
   }
}

public class ProblemGenerator
{
   private char[] _operations;
   private int _maxNumber;

   public ProblemGenerator(int maxNumber, params char[] operations)
   {
      this._operations = operations;
      this._maxNumber = maxNumber;
   }

   public MathProblem Generate()
   {
      Random random = new Random();
      // Choose operation
      char operation = _operations[random.Next(0, _operations.Length)];
      
      // Choose left operand 
      int leftOperand = random.Next(0, this._maxNumber);
       
      // Choose right operand
      int rightOperand;
      switch (operation)
      {
         case '+':
         case '-':
         case '*':
            rightOperand = random.Next(0, this._maxNumber);
            break;
         case '/':
            // Find a number that will result in even division
            do
            {
               rightOperand = random.Next(1, this._maxNumber);
            } while (leftOperand % rightOperand != 0);
            break;
         default:
            throw new InvalidOperationException($"Operation {operation} is not supported.");
      }
      
      return new MathProblem(leftOperand, operation, rightOperand); 
   }
   
   
}

