// See https://aka.ms/new-console-template for more information

using ActorRepositoryLib;
using ActorRESTConsumer;

ActorWorker worker = new ActorWorker();
List<Actor> actorList = worker.Get().Result;

foreach (Actor actor in actorList)
{
    Console.WriteLine(actor);
}

Actor actorByID = worker.GetById(1).Result;
Console.WriteLine(actorByID);