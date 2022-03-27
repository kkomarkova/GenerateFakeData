namespace GenerateFakeData.Service;

public class PhoneNoService
{
    int[] starters = new int[] {2, 30, 31, 40, 41, 42, 50, 51, 52, 53, 60, 61, 71, 81, 91, 92, 93,
        342, 344, 345, 346, 347, 348, 349, 356, 357, 359, 362, 365, 366, 389, 398, 431, 441, 462, 466,  468,  472,  474,  476,  478,  485,
        486,  488, 489,  493, 494, 495, 496,  498, 499,  542, 543,  545,  551, 552, 556, 571, 572, 573, 574, 577, 579, 584, 586, 587, 589,
        597, 598, 627, 629, 641, 649, 658, 662, 663, 664, 665, 667, 692, 693, 694, 697, 771, 772, 782, 783, 785, 786, 788, 789, 826, 827,829};
    public string GenerateRandomPhoneNumber()
    {
        string generated = "";
        Random rnd = new Random();
        const int numberLength = 8;
        //Pick one index from the array, from 0 to the length of the starters
        int startingSequence = starters[rnd.Next(0, starters.Length)];
        //How many digits are in one object
        int lengthOfStartingSequence = startingSequence.ToString().Length;
        generated += startingSequence.ToString();
        //Generate random of the digit missing from number length - length of starting sequence (1,2,3)
        for (int i = 0; i < numberLength - lengthOfStartingSequence; i++)
        {
            generated += rnd.Next(0, 10);
        }
        if(ValidatePhoneNumber(generated)) {
            return generated;
        }
        Console.WriteLine("Invalid phone number generated.");
        return null;
    }
    //Validator of Phone number
    public bool ValidatePhoneNumber(string numberToTest)
    {
        return starters.Any(x => numberToTest.StartsWith(x.ToString())) && (numberToTest.Length == 8);
    }
}