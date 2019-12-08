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
    section.code {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
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

1. Welches Problem geht MVVM an?
2. Was ist MVVM?
  2.1. Bestandteile
  2.2. Zusammenspiel
3. Anwendungsbereiche
4. Verglichen mit MVC und MVP
5. Kritische Würdigung

---

# 1. Welches Problem geht MVVM an?

- Starke Abhängigkeit zwischen UI und Logik 
- Redesign problematisch
- Cross Platform
- **TODO** weitere finden!!!

<!--
*Vorwort*: 
generell kommt es auf die ausgangassituation an, wie stark die folgenden punkte gewogen werden.

1. UI und Logik ist ein code, was schwer zu warten ist
2. da die UI und die logik viel miteinander zu tun haben kann man nicht einfach das design ändern. dabei zerstört man wahrscheinlich viele funktionen usw.
3. Es muss viel logik neu für jede plattform geschrieben werden

*schlusswort*:
wenn beispielweise Application Layer angewand wird, ist punkt 3 schonmal deutlich weniget schlimm, da man bereits eine saubere trennung zwsichen UI und Logik hat.
-->

---

# 2.1. Was ist MVVM - Bestandteile?

- Komponenten
  - Model
  - ViewModel
  - View
- Binding
- Events

---

<!-- 
_class: 
- invert
- code
-->
<span>

# 2.1. Was ist MVVM? - Model

- POCO (aka POJO)
- Nur Daten und Daten Logik

</span>

```` C#
public class StudentCollection
{
    public Student[] Students { get; }
    public Student[] FullAgeStudents { 
        get {
            return this.Students.where(x => x.Age >= 18).toList();
        }
    }
}
````



<!-- 
1. wenn das objekt eine collection beinhält und nur eine submenge zurückgeben soll. bsp. StudentCollection.getFullAgeStudents() 
-->

---

# 2.1. Was ist MVVM? - ViewModel

- Schnittstelle zwischen UI und Logik
- Zusammenführung von Daten und Funktionen 
- Verwendet beliebig viele **Model**'s

---