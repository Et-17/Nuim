# The Philosophy of Nuim

Nuim (new-eem) is a functional language that attempts to apply the 
freedom from the tyrany of parenthesis and arbitrary evaluation orders 
that RPN offers to function application. 

## Why We Don't Like Parenthesis

Anyone who has ever spent any time working with a programming language 
will know the frustration of dealing with confusions around mismathed 
parenthesis and not knowing what's happening because of the mass of 
parenthesis in the expression. Sure, there are solutions such as 
colorizing the pairs of parenthesis with different colors, but these are 
only bandages and temporary solutions that don't attack the central 
problem: parenthesis are a needlessly confusing and tedius construct 
that we have stuck onto for far too long, despite other solutions 
existing.

## The Solution

Many have been proposed. The current primary solution is operator 
preference. If there's multiple operations, one after the other, whose 
order matches the order of operator preference, you can remove the 
parenthesis. The problem with this is that the operator prefence is that 
still have to regularly deal with parenthesis when our expressions don't 
fit the preference order. Further, the orders are almost always 
completely arbitrary. While in normal mathmatics, where there aren't 
many symbols that must be included, we can remember it with simple 
acronyms like PEMDAS, when it comes to something like a computer 
programming language, we are stuck with massive graphs that can take a 
long time to memorize. Furthermore, operator preference leaves many 
ambiguities and pitfalls in which nasty and hard to find bugs can 
reside. Another possible solution is that employed by Haskell, which 
uses symbols such as `.` and `$` to avoid parenthesis when it can, but 
these as well are not a complete solution, and leave many instances 
where parenthesis are required. They also add a massive learning curve, 
which can deter people away from the language, and result in many places 
for bugs to hide in. These fixes didn't fail because they were bad, they 
failed because what they were trying to fix was fundamentally broken. 
Instead, we must completely replace inline notation with reverse polish 
notation to remove parenthesis entirely, once and for all.

## What does Nuim mean?

Nothing. It just sounded cool, wasn't used, and didn't have a negative 
connotation already.