
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"EmberBuildRunner",
        content:"EmberBuildRunner",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"EmberTool",
        content:"EmberTool",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"EmberServeSettings",
        content:"EmberServeSettings",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"EmberArgumentBuilder",
        content:"EmberArgumentBuilder",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"EmberAliases",
        content:"EmberAliases",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"EmberServeRunner",
        content:"EmberServeRunner",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"EmberBuildSettings",
        content:"EmberBuildSettings",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"EmberSettings",
        content:"EmberSettings",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember.Build/EmberBuildRunner',
        title:"EmberBuildRunner",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember/EmberTool_1',
        title:"EmberTool<TSettings>",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember.Serve/EmberServeSettings',
        title:"EmberServeSettings",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember/EmberArgumentBuilder_1',
        title:"EmberArgumentBuilder<T>",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember/EmberAliases',
        title:"EmberAliases",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember.Serve/EmberServeRunner',
        title:"EmberServeRunner",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember.Build/EmberBuildSettings',
        title:"EmberBuildSettings",
        description:""
    });

    y({
        url:'/Cake.Ember/Cake.Ember/api/Cake.Ember/EmberSettings',
        title:"EmberSettings",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
