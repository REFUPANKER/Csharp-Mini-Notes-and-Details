# CsharpWPF-Button-MouseMove-Style-Changing
changing button color at mouse over

- Pick item in form 
- Right Click / Edit Template / Edit a Copy
- Name it style and select place to writing style code
- Press OK and it done !
- Add this to item's design properties
```xml
Style="{DynamicResource fileName}"
```
### Most important step
- Dont forget to add any background to item 
```xml
<item ... Background="any" ... />
```
