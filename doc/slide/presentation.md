---
marp: true
theme: upgrade
---

<!-- _class: title-->

# MVVM Pattern
## Nico Vogel und Lukas Sopora

12.12.19

---

# Agenda

1. Welches Problem geht MVVM an?
2. Was ist MVVM?
  2.1. Bestandteile
  2.2. Zusammenspiel
3. Anwendungsbereiche
4. Vergleich mit MVC und MVP
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
<!-- _class: code -->
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
<!-- _class: code -->
<span>

# 2.1. Was ist MVVM? - ViewModel

- Schnittstelle zwischen UI und Logik
- Zusammenführung von Daten und Funktionen 
- Verwendet beliebig viele Models

</span>

````C#
public class StudentViewModel
{
    public StudentCollection ClassBook { get; }

    public StudentViewModel()
    {
        ClassBook = new StudentCollection();
        ClassBook.Students.Add(new Student("Andi Theke", 19, GenderType.Male));
    }
}
````

---
<!-- _class: code -->
<span>

# 2.1. Was ist MVVM? - View

- Kein Programmcode, lediglich Rendering
- Kennt genau ein ViewModel
- "Sucht" sich die notwendigen Informationen aus dem ViewModel

</span>

````XML
<ListView>
    <ListViewItem>
        <DockPanel>
            <TextBlock Text="Andi Theke"/>
            <TextBlock Text="19"/>
            <TextBlock Text="Male"/>
        </DockPanel>
    </ListViewItem>
</ListView>
````

---

<span>

# 2.1 Was ist MVVM? - Binding

- View bindet Eigenschaft an ViewModel
- Bessere Entkopplung beider Komponenten
- Kein Code, der View explizit updated nötig

````XML
<ListView ItemsSource="{Binding ClassBook.Students}">
    <ListView.ItemTemplate>
        <DataTemplate>
            <DockPanel>
                <TextBlock Text="{Binding Name}"/>
                <TextBlock Text="{Binding Age}"/>
                <TextBlock Text="{Binding Gender}"/>
            </DockPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
````

</span>

---
<!-- _class: split-->

# 2.1. Was ist MVVM? - Binding

<div class="ldiv">

## OneWay Binding

View → ViewModel

oder

View ← ViewModel

</div>
<div class="rdiv">

## TwoWay Binding

View ⮀ ViewModel 

</div>
