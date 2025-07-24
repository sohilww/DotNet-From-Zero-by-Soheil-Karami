---
title: Why Good Design Matters
---

# Why Good Design Matters

## 🔹 The Real‑World Cost of “Bad Code”

- **$ 2.41 trillion** – Estimated annual cost of poor software quality in the U.S. alone [2022 CISQ report](https://www.it-cisq.org/the-cost-of-poor-quality-software-in-the-us-a-2022-report/)
- **45 % budget overrun & 56 % less value** on average for large IT projects [McKinsey study](https://www.mckinsey.com/~/media/McKinsey/Business%20Functions/McKinsey%20Digital/Our%20Insights/Delivering%20large%20scale%20IT%20projects%20on%20time%20on%20budget%20and%20on%20value/Delivering%20large%20scale%20IT%20projects%20on%20time%20on%20budget%20and%20on%20value.pdf)

- **10 – 20 % of every new‑product IT budget** is typically redirected to pay off existing technical debt instead of adding features [McKinsey survey on tech debt (2020)](https://www.mckinsey.com/capabilities/mckinsey-digital/our-insights/tech-debt-reclaiming-tech-equity)

When code is hard to read or change, every feature, bug‑fix, or integration becomes slower and riskier. That cost is paid daily in engineering hours, delayed releases, lost revenue, and damage to brand trust.

## 🔹 Hidden Costs for Developers, Companies & Society

| Stakeholder             | Pain of Bad Design                                               | Long‑Term Impact                                |
| ----------------------- | ---------------------------------------------------------------- | ----------------------------------------------- |
| **Developers**          | Context‑switch fatigue, “spaghetti” debugging, career stagnation | Burnout, high turnover                          |
| **Teams / Companies**   | Missed deadlines, runaway maintenance budgets                    | Competitive disadvantage, project cancellations |
| **End Users / Society** | Outages, data loss, security breaches                            | Loss of trust, financial/legal penalties        |

## 🔹 Ethical & Professional Responsibility

Writing maintainable code is not a luxury—it’s professional ethics. Clean design:

1. **Reduces waste** – fewer re‑writes, less duplicated work
2. **Protects users** – fewer defects and security issues
3. **Elevates careers** – readable code is teachable code

## 🔹 A Quick Code‑Smell Example

```csharp
// Bad: many responsibilities crammed into one method
public void ProcessInvoice(int orderId)
{
    // 1) Data access
    var order = db.Orders.Find(orderId);

    // 2) Business rule
    decimal total = order.Items.Sum(i => i.Price);

    // 3) Presentation
    var html = $"<h1>Invoice #{orderId}</h1><p>Total: {total}</p>";

    // 4) IO side effect
    emailService.Send(order.CustomerEmail, "Your invoice", html);

}
```

> **Smells:** violates Single‑Responsibility, hard to test, hard to reuse.

🟨 **Questions for students**

- Which costs from the table above can you map to this code smell example?
- How would splitting this method into separate classes follow the Single Responsibility Principle?

---

🟦 **Practice**

- Identify one “God Method” or large class in a past project (or an online snippet).
  1. List its separate responsibilities.
  2. Propose how to refactor it into smaller, focused classes or methods.

---

## 🧹 Takeaways

- **Design debt = financial debt.** Sooner or later, someone pays with real money and time.
- **Clean code is an ethical choice.** It protects teammates, users, and the business.
