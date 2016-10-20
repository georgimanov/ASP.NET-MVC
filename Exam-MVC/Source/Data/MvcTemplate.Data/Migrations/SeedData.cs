namespace MvcTemplate.Data.Migrations
{
    using System.Collections.Generic;

    using Models;
    using System;

    public class SeedData
    {
        private List<Comment> comments;

        private List<Idea> ideas;

        private List<Vote> votes;

        public SeedData()
        {
            this.Comments = new List<Comment>();
            this.Ideas = new List<Idea>();
            this.Votes = new List<Vote>();

            var idea1 = new Idea()
            {
                AuthorIpAdress = "ip1",
                Description = "Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!",
                Title = "XNA 5"
            };

            var idea2 = new Idea()
            {
                AuthorIpAdress = "ip2",
                Description = "Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One.Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)Please make .NET a compelling game development alternative on Xbox One!",
                Title = "Allow .NET games on Xbox One"
            };

            var idea3 = new Idea()
            {
                AuthorIpAdress = "ip3",
                Description = "Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other \"config\" files.",
                Title = "Support web.config style Transforms on any file in any project type"
            };

            var idea4 = new Idea()
            {
                AuthorIpAdress = "ip4",
                Description = "I am amazed you've decided to remove Macros from Visual Studio. Not only are they useful for general programming, but they're a great way to be introduced to the Visual Studio APIs If you are unwilling to put in the development time towards them,please release the source code and let the community maintain it as an extension.",
                Title = "Bring back Macros"
            };

            var idea5 = new Idea()
            {
                AuthorIpAdress = "ip5",
                Description = @"Blog post at http://davidburela.wordpress.com/2013/11/22/is-it-time-to-open-source-silverlight/
                For all intents and purposes Microsoft now views Silverlight as “Done”. While it is no longer in active development it is still being “supported” through to 2021(source).

However there is still a section of the.Net community that would like to see further development done on the Silverlight framework.A quick look at some common request lists brings up the following stats:",
                Title = "Open source Silverlight"
            };

            var idea6 = new Idea()
            {
                AuthorIpAdress = "ip6",
                Description = @"in 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF.

Please, make nativa support for DX 11 in WOF by default and update D3DImage class to have possibility to work with nativa C++ DX 11 engine and make render directly to WPF control (controls) without pain with C++ dll.",
                Title = @"Native DirectX 11 support for WPF"
            };

            var idea7 = new Idea()
            {
                AuthorIpAdress = "ip7",
                Description = @"Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community.",
                Title = @"Make WPF open-source and accept pull-requests from the community"
            };

            var idea8 = new Idea()
            {
                AuthorIpAdress = "ip8",
                Description = @"Add support for the new JavaScript ES6 module syntax, including module definition and imports.",
                Title = @"Support for ES6 modules"
            };

            var idea9 = new Idea()
            {
                AuthorIpAdress = "ip9",
                Description = @"I'm writing this on behalf of the thousands of other Visual Studio users out there who have had nightmares trying to uninstall previous versions of VS. Thus cumulatively losing hundreds of thousands of productive work hours.

During this year, I had installed the following programs/components on my system: 
* Visual Studio 2012 Express for Desktop 
* Visual Studio 2012 Express for Web 
* Team Foundation Server Express 
* SQL Server Express 
* SQL Server Data Tools 
* LightSwitch 2011 trial (which created a VS 2010 installation) 
* Visual Studio 2010 Tools for SQL Server Compact 3.5 SP2 ",
                Title = "Create a \"remove all remnants of Visual Studio from your system\" program."
            };

            var idea10 = new Idea()
            {
                AuthorIpAdress = "ip10",
                Description = @"To build certain PCL libraries and libraries for Windows 8 RT requires having Visual Studio on the server.

Nick Berardi writes about a workaround that allows running a build server without VS, but it's really just a workaround for functionality that should be easy.

Not to mention there's probably licensing considerations we're just ignoring by doing that.

http://nickberardi.com/a-net-build-server-without-visual-studio/

Please make it easy (and legal) to build .NET projects on a server without requiring a Visual Studio installation (or license) on that server.",
                Title = @"Support .NET Builds without requiring Visual Studio on the server",
            };

            this.Ideas.Add(idea1);
            this.Ideas.Add(idea2);
            this.Ideas.Add(idea3);
            this.Ideas.Add(idea4);
            this.Ideas.Add(idea5);
            this.Ideas.Add(idea6);
            this.Ideas.Add(idea7);
            this.Ideas.Add(idea8);
            this.Ideas.Add(idea9);
            this.Ideas.Add(idea10);

            var random = new Random();
            foreach (var idea in this.Ideas)
            {
                for (int i = 0; i < 10; i++)
                {
                    var comment = new Comment()
                    {
                        AuthorEmail = $"pesho{i}@abv.bg",
                        Content = $"Comment content {i}",
                        AuthorIp = $"ip{i}"
                    };
                    idea.Comments.Add(comment);
                }

                for (int i = 0; i < 100; i++)
                {
                    var rand = random.Next(0, 3);
                    var vote = new Vote()
                    {
                        Points = rand,
                        AuthorIp = string.Format("ip-{0}", rand + i),
                    };
                    idea.Votes.Add(vote);
                }
            }
        }

        public List<Comment> Comments
        {
            get
            {
                return comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public List<Idea> Ideas
        {
            get
            {
                return ideas;
            }

            set
            {
                this.ideas = value;
            }
        }

        public List<Vote> Votes
        {
            get
            {
                return votes;
            }

            set
            {
                this.votes = value;
            }
        }
    }
}
