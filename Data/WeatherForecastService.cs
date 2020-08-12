using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Numbers.Data
{
				public class NumbersService
				{
								public static bool IsPrime(int number)
								{
												for (int i = 2; i < number; i++)
												{
																if (number % i == 0) return false;
												}

												return true;
								}

								public static int NextNumber()
								{
												var rng = new Random();

												int newNumber = rng.Next(0, 1000);

												while (IsPrime(newNumber))
												{
																newNumber = rng.Next(0, 1000);
												}

												return newNumber;
								}

								public Task<Numbers[]> GetNumbersAsyncNoPrimeNumbers()
								{
												var results = Task.FromResult(Enumerable.Range(1, 8).Select(index => new Numbers
												{
																Number = NextNumber()
												}).ToArray()); ;

												return results;
								}

								public Task<Numbers[]> GetNumbersAsync()
								{
												var rng = new Random();

												return Task.FromResult(Enumerable.Range(1, 8).Select(index => new Numbers
												{
																Number = rng.Next(0, 1000)
												}).ToArray()); ;
								}
				}
}
