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
    section .columnFlex {
        display: flex;
        flex-direction: row;
        text-align: center;
        height: 100%;
    }
    section .columnFlex div {
        background-color: #333;
        margin: 20px;
        padding: 10px 0px;
        height: 100%;
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

<!-- 
1. wenn das objekt eine collection beinhält und nur eine submenge zurückgeben soll. bsp. StudentCollection.getFullAgeStudents() 
-->

</span>

```` C#
public class StudentCollection
{
    public IList<Student> Students { get; }
    public IList<Student> FullAgeStudents 
    { 
        get 
        {
            return this.Students.where(x => x.Age >= 18).toList();
        }
    }
}
````


---
<!-- 
_class: 
- invert
- code
-->
<span>

# 2.1. Was ist MVVM? - ViewModel

- Schnittstelle zwischen UI und Logik
- Zusammenführung von Daten und Funktionen 
- Verwendet beliebig viele **Model**'s

</span>

````C#
// TODO code
````

---
<!-- 
_class: 
- invert
- code
-->
<span>

# 2.1. Was ist MVVM? - View

- Nur Design
- Kein Programmcode
- Kennt genau ein ViewModel
- "Sucht" sich die notwendigen Informationen aus dem ViewModel

</span>

````C#
// TODO code
````

---

# 2.1. Was ist MVVM? - Binding

<span class="columnFlex">
<div>

## OneWay Binding

von View zu ViewModel oder von ViewModel zu View

</div>
<div>

## TwoWay Binding

Von der View zum ViewModel und gleichzeitig auch andersrum

</div>
</span>
