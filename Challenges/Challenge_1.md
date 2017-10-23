CHALLENGE 1: Crear acciones Details, Delete y Update (10min)



Delete

* Pasar id del modelo a borrar como parámetro en la URL (SongGenres/Delete/{id})

* Después de eliminar la entidad, redirigir a la acción Index 

  ```c#
  return RedirectToAction("Index");
  ```

> Pista
>
> ```c#
> context.SongGenres.Remove(songGenreToRemove);
> ```



### Details

* Pasar id del modelo a mostrar como parámetro en la URL (SongGenres/Details/{id})
* Mostrar información de ese modelo en la vista Details



> Pista
>
> ```c#
> var songGenre = context.SongGenres.Find(id);
> ```



### Update

- Pasar id del modelo a modificar como parámetro en la URL (SongGenres/Update/{id})

- Después de realizar la modificación, redirigir a la acción Index 

  ```c#
   return RedirectToAction("Index");
  ```

> Pista
>
> ```c#
> context.SongGenres.AddOrUpdate(songGenreToUpdate);
> ```



**Collejaca pal que se deje el context.SaveChanges()!**
