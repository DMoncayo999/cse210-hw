using System;
using System.Collections.Generic;

public class PromptGenerator
{

    public List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most unexpected thing that happened today?",
            "Describe a moment of kindness you witnessed or experienced today.",
            "Reflect on a challenge you encountered today and how you handled it.",
            "Share a goal you accomplished today, no matter how small.",
            "Recall a funny or memorable moment from today.",
            "Think about something you learned today and how it impacted you.",
            "Reflect on a decision you made today and its outcome.",
            "Share something you're grateful for today."

        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
        
}