---

marp: true
paginatie: true
theme: 
class: 
- invert
style: |
    section.lead {
        text-align: center;
        justify-content: center;
    }
    section {
        justify-content: initial;
    }


---

<!-- 
_class: 
- lead
- invert-->

# MVVM Pattern
Nico Vogel und Lukas Supora

12.12.19

---

# Agenda

- Welches Problem geht MVVM an?
- Was ist MVVM?
- Anwendungsbereiche
- Verglichen mit MVC und MVP
- Kritische Würdigung

---

# Welches Problem geht MVVM an?

- Starke Abhängigkeit zwischen UI und Logik 
- Redesign problematisch
- Cross Platform

<!--
*Vorwort*: 
generell kommt es auf die ausgangassituation an, wie stark die folgenden punkte gewogen werden.

1. UI und Logik ist ein code, was schwer zu warten ist
2. da die UI und die logik viel miteinander zu tun haben kann man nicht einfach das design ändern. dabei zerstört man wahrscheinlich viele funktionen usw.
3. Es muss viel logik neu für jede plattform geschrieben werden
4. 

*schlusswort*:
wenn beispielweise Application Layer angewand wird, ist punkt 3 schonmal deutlich weniget schlimm, da man bereits eine saubere trennung zwsichen UI und Logik hat.
-->

---