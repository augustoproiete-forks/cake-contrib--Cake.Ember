
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"EmberTool",
            content:"EmberTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember/EmberTool_1',
            title:"EmberTool<TSettings>",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"EmberAliases",
            content:"EmberAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember/EmberAliases',
            title:"EmberAliases",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"EmberSettings",
            content:"EmberSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember/EmberSettings',
            title:"EmberSettings",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"EmberBuildRunner",
            content:"EmberBuildRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember.Build/EmberBuildRunner',
            title:"EmberBuildRunner",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"EmberServeRunner",
            content:"EmberServeRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember.Serve/EmberServeRunner',
            title:"EmberServeRunner",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"EmberArgumentBuilder",
            content:"EmberArgumentBuilder",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember/EmberArgumentBuilder_1',
            title:"EmberArgumentBuilder<T>",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"EmberBuildSettings",
            content:"EmberBuildSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember.Build/EmberBuildSettings',
            title:"EmberBuildSettings",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"EmberServeSettings",
            content:"EmberServeSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Ember/api/Cake.Ember.Serve/EmberServeSettings',
            title:"EmberServeSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
