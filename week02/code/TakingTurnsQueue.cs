public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns. An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the first person in the queue
        var person = _people.Dequeue();

        // If the person has finite turns, decrement their turns and re-enqueue them if they have turns left.
        if (person.Turns > 0)
        {
            person.Turns -= 1;
            if (person.Turns > 0) // Only re-enqueue if they still have turns left
            {
                _people.Enqueue(person);
            }
        }
        else
        {
            // If the person has infinite turns (turns <= 0), re-enqueue them without decrementing.
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => $"{p.Name} (Turns: {p.Turns})"));
    }
}


